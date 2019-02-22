using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    public class BankDetailsController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly IBankDetailRepository _bank;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public BankDetailsController(NajmetAlraqeeContext context, IBankDetailRepository bank, IMapper mapper, IToastNotification toastNotification)
        {
            _context = context;
            _bank = bank;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        #region Index 
        public IActionResult Index(int? page)
        {
            var banks = _bank.GetBankDetails();
            ViewBag.Banks = banks;
            //if (nationality.Count() <= 10) { page = 1; }
            //int pageSize = 10;
            return View();
        }
        #endregion






        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(BankDetailViewModels bankDetailViewModels)
        {
            var banksList = _bank.GetBankDetails();
            ViewBag.Banks = banksList;
            if (bankDetailViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var bankdetail = _mapper.Map<BankDetail>(bankDetailViewModels);
                    _bank.AddBankDetail(bankdetail);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالبنك بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), bankDetailViewModels);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var bankdetail = _mapper.Map<BankDetail>(bankDetailViewModels);
                    _bank.UpdateBankDetail(bankDetailViewModels.Id, bankdetail);
                    _toastNotification.AddSuccessToastMessage("تم تعديل البنك بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), bankDetailViewModels);
            }

        }


        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankdetail = _bank.GetBankDetailById((int)id);
            var bankDetailViewModels = _mapper.Map<BankDetailViewModels>(bankdetail);
            if (bankdetail == null)
            {
                return NotFound();
            }
            var banksList = _bank.GetBankDetails();
            ViewBag.Banks = banksList;
            return View("Index", bankDetailViewModels);
        }
        #region Delete

        public IActionResult Delete(int id)
        {
            _bank.RemoveBankDetail(id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion 


    }
}