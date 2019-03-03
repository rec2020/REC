using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    public class PartnerController : Controller
    {
        private readonly IPartnerRepository _partner;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public PartnerController(IPartnerRepository partner, IMapper mapper, IToastNotification toastNotification)
        {
            _partner = partner;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        #region Index 
        public IActionResult Index(int? page)
        {
            var partnerList = _partner.GetPartners();
            ViewBag.Partners = partnerList;
            //if (nationality.Count() <= 10) { page = 1; }
            //int pageSize = 10;
            return View();
        }
        #endregion




        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddPost(PartnerViewModel partnerViewModels)
        {
            var partnerList = _partner.GetPartners();
            ViewBag.Partners = partnerList;
            if (partnerViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var partner = _mapper.Map<Partner>(partnerViewModels);
                    _partner.AddPartner(partner);
                    _toastNotification.AddSuccessToastMessage("تم بيانات الشريك بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), partnerViewModels);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var partner = _mapper.Map<Partner>(partnerViewModels);
                    _partner.UpdatePartner(partnerViewModels.Id, partner);
                    _toastNotification.AddSuccessToastMessage("تم تعديل بيانات الشريك بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), partnerViewModels);
            }
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = _partner.GetPartnerById((int)id);
            var partnerViewModel = _mapper.Map<PartnerViewModel>(partner);
            if (partner == null)
            {
                return NotFound();
            }
            var partnerList = _partner.GetPartners();
            ViewBag.Partners = partnerList;
            return View("Index", partnerViewModel);
        }

        #region Delete

        public IActionResult Delete(int id)
        {
            _partner.RemovePartner(id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion 

    }
}