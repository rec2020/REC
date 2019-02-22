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
    public class ArrivalController : Controller
    {
        private readonly IArrivalRepository _arrival;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        public ArrivalController(IArrivalRepository arrival, IMapper mapper, IToastNotification toastNotification)
        {
            _arrival = arrival;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        #region Index 
        public IActionResult Index(int? page)
        {
            var arrivalList = _arrival.GetArrivals();
            ViewBag.Arrival = arrivalList;

            //if (arrival.Count() <= 10) { page = 1; }
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
        public IActionResult AddPost(ArrivalViewModel arrivalViewModel)
        {

            var arrivalList = _arrival.GetArrivals();
            ViewBag.Arrival = arrivalList;
            if (arrivalViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var arrival = _mapper.Map<Arrival>(arrivalViewModel);
                    _arrival.AddArrival(arrival);
                    _toastNotification.AddSuccessToastMessage("تم أضافة جهة الوصول  بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), arrivalViewModel);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var arrival = _mapper.Map<Arrival>(arrivalViewModel);
                    _arrival.UpdateArrival(arrivalViewModel.Id, arrival);
                    _toastNotification.AddSuccessToastMessage("تم تعديل جهة الوصول بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), arrivalViewModel);
            }

        }
        //return View("Index",arrivalViewModel);




        #region Edit
        // GET: Doctors1/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrival = _arrival.GetArrivalById((int)id);
            var arrivalViewModel = _mapper.Map<ArrivalViewModel>(arrival);
            if (arrival == null)
            {
                return NotFound();
            }
            var arrivalList = _arrival.GetArrivals();
            ViewBag.arrival = arrivalList;
            return View("Index", arrivalViewModel);
        }


        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            _arrival.RemoveArrival(id);
            _toastNotification.AddSuccessToastMessage("تم الحذف  بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}