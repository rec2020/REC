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
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

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

        public ReceiptDocController(IContractRepository contract, ICustomerRepository customer, IReceiptDocRepository receipt, IReceiptDocTypeRepository type, IUserRepository user, IMapper mapper, IToastNotification toastNotification)
        {
            _user = user;
            _contrat = contract;
            _customer = customer;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _type = type;
            _receipt = receipt;
        }
        #region SnadReceiveIndex
        public IActionResult SnadReceiveIndex(int contractId)
        {
            ReceiptDocViewModel receiptDoc = new ReceiptDocViewModel();
            receiptDoc.ContractId = contractId;
            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ContractId == contractId && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive);
            ViewBag.ReceiptDocs = ReceiptDocList;
            var custom = _contrat.GetContractById(contractId);
            if (custom != null)
            {
                receiptDoc.CustomerId = custom.CustomerId;
            }
            receiptDoc.ReceiptdocTypeId = (int)EnumHelper.ReceiptdocType.SnadReceive;
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes().Where(x=>x.Id== receiptDoc.ReceiptdocTypeId), "Id", "Name");
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSnadReceive(ReceiptDocViewModel recieptViewModel)
        {
            recieptViewModel.ReceiptByUserName = User.Identity.Name;
            var receiptById = _user.GetUserByName(recieptViewModel.ReceiptByUserName);
            recieptViewModel.ReceiptByUser = receiptById.Id;
            recieptViewModel.ReceiptdocTypeId = (int)EnumHelper.ReceiptdocType.SnadReceive;
            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ContractId == recieptViewModel.ContractId && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive); 
            ViewBag.ReceiptDocs = ReceiptDocList;
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes(), "Id", "Name", recieptViewModel.ReceiptdocTypeId);
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName", recieptViewModel.CustomerId);
            if (recieptViewModel.Id == 0)
            {
                ModelState.Remove("ReceiptdocTypeId");
                ModelState.Remove("CustomerId");
                if (ModelState.IsValid)
                {
                    var receipt = _mapper.Map<ReceiptDoc>(recieptViewModel);
                    _receipt.AddReceiptDoc(receipt);
                    _toastNotification.AddSuccessToastMessage("تم ادخال ادخال سند الصرف بنجاح ");
                    return RedirectToAction(nameof(SnadReceiveIndex), new { contractId = recieptViewModel.ContractId });
                }
                return View(nameof(SnadReceiveIndex), recieptViewModel);
            }
            else
            {
                ModelState.Remove("ReceiptdocTypeId");
                ModelState.Remove("CustomerId");
                if (ModelState.IsValid)
                {
                    var receipt = _mapper.Map<ReceiptDoc>(recieptViewModel);
                    _receipt.UpdateReceiptDoc(recieptViewModel.Id, receipt);
                    _toastNotification.AddSuccessToastMessage("تم تعديل سند الصرف بنجاح");
                    return RedirectToAction(nameof(SnadReceiveIndex), new { contractId = recieptViewModel.ContractId });
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
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes(), "Id", "Name", receiptViewModel.ReceiptdocTypeId);
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName", receiptViewModel.CustomerId);
            return View("SnadReceiveIndex", receiptViewModel);
        }


        #endregion




        #region SnadSnadTakingIndex
        public IActionResult SnadTakingIndex(int contractId)
        {
            ReceiptDocViewModel receiptDoc = new ReceiptDocViewModel();
            receiptDoc.ContractId = contractId;
            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ContractId == contractId && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking);
            ViewBag.TakingDocs = ReceiptDocList;
            var custom = _contrat.GetContractById(contractId);
            if (custom != null)
            {
                receiptDoc.CustomerId = custom.CustomerId;
            }
            receiptDoc.ReceiptdocTypeId = (int)EnumHelper.ReceiptdocType.SnadTaking;
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
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSnadTaking(ReceiptDocViewModel recieptViewModel)
        {
            recieptViewModel.ReceiptByUserName = User.Identity.Name;
            var receiptById = _user.GetUserByName(recieptViewModel.ReceiptByUserName);
            recieptViewModel.ReceiptByUser = receiptById.Id;
            recieptViewModel.ReceiptdocTypeId = (int)EnumHelper.ReceiptdocType.SnadTaking;
            var ReceiptDocList = _receipt.GetReceiptDocs().Where(x => x.ContractId == recieptViewModel.ContractId && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking);
            ViewBag.TakingDocs = ReceiptDocList;
            ViewBag.ReceiptdocTypeId = new SelectList(_type.GetReceiptDocTypes(), "Id", "Name", recieptViewModel.ReceiptdocTypeId);
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName", recieptViewModel.CustomerId);
            if (recieptViewModel.Id == 0)
            {
                ModelState.Remove("ReceiptdocTypeId");
                ModelState.Remove("CustomerId");
                if (ModelState.IsValid)
                {
                    var receipt = _mapper.Map<ReceiptDoc>(recieptViewModel);
                    _receipt.AddReceiptDoc(receipt);
                    _toastNotification.AddSuccessToastMessage("تم ادخال ادخال سند القبض بنجاح ");
                    return RedirectToAction(nameof(SnadTakingIndex), new { contractId = recieptViewModel.ContractId });
                }
                return View(nameof(SnadTakingIndex), recieptViewModel);
            }
            else
            {
                ModelState.Remove("ReceiptdocTypeId");
                ModelState.Remove("CustomerId");
                if (ModelState.IsValid)
                {
                    var receipt = _mapper.Map<ReceiptDoc>(recieptViewModel);
                    _receipt.UpdateReceiptDoc(recieptViewModel.Id, receipt);
                    _toastNotification.AddSuccessToastMessage("تم تعديل سند القبض بنجاح");
                    return RedirectToAction(nameof(SnadTakingIndex), new { contractId = recieptViewModel.ContractId });
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
    }

}