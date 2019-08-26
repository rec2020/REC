using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;
using Rotativa.AspNetCore;

namespace NajmetAlraqee.Site.Controllers
{
    public class InvoiceController : Controller
    {
     
        private readonly IInvoiceRepository _invoice;
        private readonly IContractRepository _contract;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public InvoiceController( IInvoiceRepository invoice, IContractRepository contract, IMapper mapper, IToastNotification toastNotification)
        {
            _invoice = invoice;
            _mapper = mapper;
            _contract = contract;
            _toastNotification = toastNotification;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, int SearchString)
        {
            var invoiceList = _invoice.GetInvoices();

            if (SearchString > 0 )
            {
                invoiceList = _invoice.GetInvoices().Where(x => x.ContractNo ==SearchString);
            }
            else
            {
                invoiceList = _invoice.GetInvoices();
            }
            
            if (invoiceList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var invoicepage = await PaginatedList<Invoice>.CreateAsync(invoiceList.AsNoTracking(), page ?? 1, pageSize);
            ViewBag.Invoices = invoicepage;
            return View(invoicepage);
        }
        #endregion

        #region Details
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var invoice = _invoice.GetInvoiceById((int)id);
            var invoiceViewModel = _mapper.Map<InvoiceViewModel>(invoice);
            if (invoice != null)
            {
                invoiceViewModel.Amount = invoice.Amount;
                invoiceViewModel.ContractNo = invoice.ContractNo;
                invoiceViewModel.Note = invoice.Note;
                invoiceViewModel.InvoiceDate = invoice.InvoiceDate;
            }

            if (invoiceViewModel == null)
            {
                return NotFound();
            }

            return View(invoiceViewModel);
        }
        #endregion

        #region Add 
        [HttpGet]
        public IActionResult Add(int contractId)
        {
            var getcontactonfo = _contract.GetContractById(contractId);
            InvoiceViewModel invoice = new InvoiceViewModel
            {
                ContractNo = getcontactonfo.Id,
                Amount = getcontactonfo.ContractCost,
                Note = getcontactonfo.QulaficationNote,
                Customer = getcontactonfo.Customer.FirstName + " " + getcontactonfo.Customer.LastName,
                VatValue = getcontactonfo.VatCost
            };
            invoice.VatPercentage = (invoice.VatValue / invoice.Amount) * 100;
            return View(invoice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(InvoiceViewModel invoiceViewModel)
        {
            if (invoiceViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var invoice = _mapper.Map<Invoice>(invoiceViewModel);
                    _invoice.AddInvoice(invoice);
                    _toastNotification.AddSuccessToastMessage("تم أضافة بيانات الفاتورة بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(invoiceViewModel);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var invoicedata = _mapper.Map<Invoice>(invoiceViewModel);
                    invoicedata.Note = invoiceViewModel.Note;
                    _invoice.UpdateInvoice(invoiceViewModel.Id, invoicedata);
                    _toastNotification.AddSuccessToastMessage("تم تعديل بيانات الفاتورة بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(invoiceViewModel);
            }

        }
        #endregion

        #region Edit 
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var invoice = _invoice.GetInvoiceById((int)id);
            var invoiceViewModel = _mapper.Map<InvoiceViewModel>(invoice);
            if (invoice == null)
            {
                return NotFound();
            }
            var invoicelist = _invoice.GetInvoices();
            ViewBag.Customers = invoicelist;
            return View("Add", invoiceViewModel);
        }
        #endregion

        #region PrintSnadReceipt 
        public ActionResult PrintInvoice(int id)
        {
            var invoice = _invoice.GetInvoiceById(id);
            ViewBag.LawyerAmount = Helper.ConvertNumbersToArabicAlphabet.NumberToWords(10000);
            ViewBag.ContractAmount = Helper.ConvertNumbersToArabicAlphabet.NumberToWords((int)invoice.Amount);
            return new ViewAsPdf("PrintInvoice", invoice)
            {
                FileName = "PrintInvoiceNo_" + invoice.Id + ".pdf"
            };
            // return View("PrintSnadTaking", snadtaking);
        }
        #endregion


    }
}