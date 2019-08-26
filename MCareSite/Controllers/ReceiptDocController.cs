using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
//using NajmetAlraqee.Site.Helper;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;
using Rotativa.AspNetCore;

namespace NajmetAlraqee.Site.Controllers
{
    public class ReceiptDocController : Controller
    {

        private readonly IContractRepository _contrat;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IReceiptDocRepository _receipt;
        private readonly IReceiptDocTypeRepository _type;
        private readonly IUserRepository _user;
        public readonly ICustomerRepository _customer;
        public readonly ISpecificContractRepository _spec_contract;
        public readonly IPaymentMethodRepository _payment_Method;

        public ReceiptDocController(IContractRepository contract, 
            ISpecificContractRepository spec_contract,
            IPaymentMethodRepository payment_Method,
            ICustomerRepository customer, 
            IReceiptDocRepository receipt, 
            IReceiptDocTypeRepository type,
            IUserRepository user, 
            IMapper mapper, 
            IToastNotification toastNotification)
        {
            _spec_contract = spec_contract;
            _user = user;
            _payment_Method = payment_Method;
            _contrat = contract;
            _customer = customer;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _type = type;
            _receipt = receipt;
        }
        #region SnadReceiveIndex
        public IActionResult SnadReceiveIndex(int contractId, int contractType)
        {
            var contract_Value = new Contract();
            var specContr = new SpecificContract();
            ReceiptDocViewModel receiptDoc = new ReceiptDocViewModel();
            if (contractType <= (int)EnumHelper.ContractType.Substitute)
            {
                contract_Value = _contrat.GetContractById(contractId);
                if (contract_Value != null)
                {
                    receiptDoc.CustomerId = contract_Value.CustomerId;
                }
            }
            else
            {
                specContr = _spec_contract.GetSpecificContractById(contractId);
                if (specContr != null)
                {
                    receiptDoc.CustomerId = specContr.CustomerId;
                }
            }
            receiptDoc.ContractTypeId = contractType;
            receiptDoc.ContractId = contractId;
            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ContractId == contractId
            && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive && x.ContractTypeId == receiptDoc.ContractType);
            ViewBag.ReceiptDocs = ReceiptDocList;

            receiptDoc.ReceiptdocTypeId = (int)EnumHelper.ReceiptdocType.SnadReceive;
            ViewBag.PaymentMethodId = new SelectList(_payment_Method.GetPaymentMethods(), "Id", "Name");
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes().Where(x => x.Id == receiptDoc.ReceiptdocTypeId), "Id", "Name");
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers().Where(x => x.Id == receiptDoc.CustomerId), "Id", "FirstName", receiptDoc.CustomerId);
            return View(receiptDoc);
        }
        #endregion

        #region AddSnadReceive

        [HttpGet]
        public IActionResult AddSnadReceive()
        {
            var ReceiptDocList = _receipt.GetReceiptDocs();
            ViewBag.ReceiptDocs = ReceiptDocList;
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes(), "Id", "Name");
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName");
            //ViewBag.PaymentMethodId = new SelectList(_payment_Method.GetPaymentMethods(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSnadReceive(ReceiptDocViewModel recieptViewModel)
        {

            var contract = _contrat.GetContractById((int)recieptViewModel.ContractId);
            if (recieptViewModel.PaymentMethodId == null) { ModelState.AddModelError("", "الرجاء تحديد طريقة الدفع"); }
            if (contract != null)
            {
                if (recieptViewModel.Amount > contract.Paid)
                {
                    ModelState.AddModelError("", "مبلغ الصرف اكبر من المبلغ المدفوع للعقد");
                }
            }
            recieptViewModel.ReceiptByUserName = User.Identity.Name;
            var receiptById = _user.GetUserByName(recieptViewModel.ReceiptByUserName);
            recieptViewModel.ReceiptByUser = receiptById.Id;
            recieptViewModel.ReceiptdocTypeId = (int)EnumHelper.ReceiptdocType.SnadReceive;
            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ContractId == recieptViewModel.ContractId
            && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive && x.ContractTypeId == recieptViewModel.CustomerId);
            ViewBag.ReceiptDocs = ReceiptDocList;
            ViewBag.PaymentMethodId = new SelectList(_payment_Method.GetPaymentMethods(), "Id", "Name");
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes(), "Id", "Name", recieptViewModel.ReceiptdocTypeId);
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName", recieptViewModel.CustomerId);
            if (recieptViewModel.Id == 0)
            {
                ModelState.Remove("ReceiptdocTypeId");
                ModelState.Remove("CustomerId");
                ModelState.Remove("PaymentMethodId");
                if (ModelState.IsValid)
                {
                    var receipt = _mapper.Map<ReceiptDoc>(recieptViewModel);
                    _receipt.AddReceiptDoc(receipt);
                    _toastNotification.AddSuccessToastMessage("تم ادخال ادخال سند الصرف بنجاح ");
                    return RedirectToAction(nameof(SnadReceiveIndex), new { contractId = recieptViewModel.ContractId, contractType = recieptViewModel.ContractTypeId });
                }
                return View(nameof(SnadReceiveIndex), recieptViewModel);
            }
            else
            {
                ModelState.Remove("ReceiptdocTypeId");
                ModelState.Remove("CustomerId");
                ModelState.Remove("PaymentMethodId");
                if (ModelState.IsValid)
                {
                    var receipt = _mapper.Map<ReceiptDoc>(recieptViewModel);
                    _receipt.UpdateReceiptDoc(recieptViewModel.Id, receipt);
                    _toastNotification.AddSuccessToastMessage("تم تعديل سند الصرف بنجاح");
                    return RedirectToAction(nameof(SnadReceiveIndex), new { contractId = recieptViewModel.ContractId, contractType = recieptViewModel.ContractTypeId });
                }
                return View(nameof(SnadReceiveIndex), recieptViewModel);
            }

        }
        #endregion

        #region EditSnadReceive
        public IActionResult EditSnadReceive(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var receipt = _receipt.GetReceiptDocById((int)id);
            var receiptViewModel = _mapper.Map<ReceiptDocViewModel>(receipt);
            if (receipt == null)
            {
                return NotFound();
            }
            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ContractId == receipt.ContractId && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive);
            ViewBag.ReceiptDocs = ReceiptDocList;
            ViewBag.PaymentMethodId = new SelectList(_payment_Method.GetPaymentMethods(), "Id", "Name");
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes(), "Id", "Name", receiptViewModel.ReceiptdocTypeId);
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName", receiptViewModel.CustomerId);
            return View("SnadReceiveIndex", receiptViewModel);
        }


        #endregion




        #region SnadSnadTakingIndex
        public IActionResult SnadTakingIndex(int contractId, int contractType)
        {
            ReceiptDocViewModel receiptDoc = new ReceiptDocViewModel
            {
                ContractId = contractId,
                ContractTypeId = contractType
            };
            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ContractId == contractId
            && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking && x.ContractTypeId == receiptDoc.ContractTypeId);
            ViewBag.TakingDocs = ReceiptDocList;
            var custom = _contrat.GetContractById(contractId);
            if (custom != null)
            {
                receiptDoc.CustomerId = custom.CustomerId;
            }
            receiptDoc.ReceiptdocTypeId = (int)EnumHelper.ReceiptdocType.SnadTaking;
            ViewBag.PaymentMethodId = new SelectList(_payment_Method.GetPaymentMethods(), "Id", "Name");
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes().Where(x => x.Id == receiptDoc.ReceiptdocTypeId), "Id", "Name");
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers().Where(x => x.Id == receiptDoc.CustomerId), "Id", "FirstName", receiptDoc.CustomerId);
            return View(receiptDoc);
        }
        #endregion

        #region AddSnadTaking

        [HttpGet]
        public IActionResult AddSnadTaking()
        {

            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking);
            ViewBag.TakingDocs = ReceiptDocList;
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes(), "Id", "Name");
            ViewBag.PaymentMethodId = new SelectList(_payment_Method.GetPaymentMethods(), "Id", "Name");
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSnadTaking(ReceiptDocViewModel recieptViewModel)
        {
            var contract = _contrat.GetContractById((int)recieptViewModel.ContractId);
            if (recieptViewModel.PaymentMethodId == null) { ModelState.AddModelError("", "الرجاء تحديد طريقة الدفع"); }
            if (contract != null)
            {
                if (recieptViewModel.Amount > contract.Remainder)
                {
                    ModelState.AddModelError("", "مبلغ القبض اكبر من المبلغ المتبقي للعقد");
                }
            }
            recieptViewModel.ReceiptByUserName = User.Identity.Name;
            var receiptById = _user.GetUserByName(recieptViewModel.ReceiptByUserName);
            recieptViewModel.ReceiptByUser = receiptById.Id;
            recieptViewModel.ReceiptdocTypeId = (int)EnumHelper.ReceiptdocType.SnadTaking;
            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ContractId == recieptViewModel.ContractId
            && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking && x.ContractTypeId == recieptViewModel.ContractTypeId);
            ViewBag.TakingDocs = ReceiptDocList;
            ViewBag.PaymentMethodId = new SelectList(_payment_Method.GetPaymentMethods(), "Id", "Name");
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes(), "Id", "Name", recieptViewModel.ReceiptdocTypeId);
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName", recieptViewModel.CustomerId);
            if (recieptViewModel.Id == 0)
            {
                ModelState.Remove("ReceiptdocTypeId");
                ModelState.Remove("CustomerId");
                ModelState.Remove("PaymentMethodId");
                if (ModelState.IsValid)
                {
                    var receipt = _mapper.Map<ReceiptDoc>(recieptViewModel);
                    _receipt.AddReceiptDoc(receipt);
                    _toastNotification.AddSuccessToastMessage("تم ادخال ادخال سند القبض بنجاح ");
                    return RedirectToAction(nameof(SnadTakingIndex), new { contractId = recieptViewModel.ContractId, contractType = recieptViewModel.ContractTypeId });
                }
                return View(nameof(SnadTakingIndex), recieptViewModel);
            }
            else
            {
                ModelState.Remove("ReceiptdocTypeId");
                ModelState.Remove("CustomerId");
                ModelState.Remove("PaymentMethodId");
                if (ModelState.IsValid)
                {
                    var receipt = _mapper.Map<ReceiptDoc>(recieptViewModel);
                    _receipt.UpdateReceiptDoc(recieptViewModel.Id, receipt);
                    _toastNotification.AddSuccessToastMessage("تم تعديل سند القبض بنجاح");
                    return RedirectToAction(nameof(SnadTakingIndex), new { contractId = recieptViewModel.ContractId, contractType = recieptViewModel.ContractTypeId });
                }
                return View(nameof(SnadTakingIndex), recieptViewModel);
            }

        }
        #endregion

        #region EditSnadTaking
        public IActionResult EditSnadTaking(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var receipt = _receipt.GetReceiptDocById((int)id);
            var receiptViewModel = _mapper.Map<ReceiptDocViewModel>(receipt);
            if (receipt == null)
            {
                return NotFound();
            }
            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking && x.ContractId == receipt.ContractId);
            ViewBag.TakingDocs = ReceiptDocList;
            ViewBag.PaymentMethodId = new SelectList(_payment_Method.GetPaymentMethods(), "Id", "Name");
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes(), "Id", "Name", receiptViewModel.ReceiptdocTypeId);
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName", receiptViewModel.CustomerId);
            return View("SnadTakingIndex", receiptViewModel);
        }
        #endregion



        #region Delete

        public IActionResult DeleteSnadReceive(int? id)
        {
            _receipt.RemoveReceiptDoc((int)id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(SnadReceiveIndex));
        }
        #endregion

        #region PrintSnadTaking 
        public ActionResult PrintSnadTaking(int id)
        {
            var snadtaking = _receipt.GetReceiptDocById(id);
            ViewBag.LawyerAmount = Helper.ConvertNumbersToArabicAlphabet.NumberToWords(10000);
            ViewBag.ContractAmount = Helper.ConvertNumbersToArabicAlphabet.NumberToWords((int)snadtaking.Amount);
            return new ViewAsPdf("PrintSnadTaking", snadtaking)
            {
                FileName = "SnadTakingFor_" + snadtaking.ContractId + ".pdf"
            };
           // return View("PrintSnadTaking", snadtaking);
        }
        #endregion

        #region PrintSnadReceipt 
        public ActionResult PrintSnadReceipt(int id)
        {
            var snadtaking = _receipt.GetReceiptDocById(id);
            ViewBag.LawyerAmount = Helper.ConvertNumbersToArabicAlphabet.NumberToWords(10000);
            ViewBag.ContractAmount = Helper.ConvertNumbersToArabicAlphabet.NumberToWords((int)snadtaking.Amount);
            return new ViewAsPdf("PrintSnadReceipt", snadtaking)
            {
                FileName = "SnadReceiptFor_" + snadtaking.ContractId + ".pdf"
            };
            // return View("PrintSnadTaking", snadtaking);
        }
        #endregion

    }

}