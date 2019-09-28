using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class JobTypesController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly IJobTypeReository _jobtype;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public JobTypesController(NajmetAlraqeeContext context, IJobTypeReository jobtype, IMapper mapper ,IToastNotification toastNotification)
        {
            _context = context;
            _jobtype = jobtype;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        #region Index 
        public IActionResult Index(int? page)
        {
            var jobtypeList = _jobtype.GetJobTypes();
            ViewBag.JobTypes = jobtypeList;
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
        public IActionResult AddPost(JobTypeViewModels jobTypeViewModels)
        {
            var jobtypeList = _jobtype.GetJobTypes();
            ViewBag.JobTypes = jobtypeList;
            if (jobTypeViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var jobtype = _mapper.Map<JobType>(jobTypeViewModels);
                    _jobtype.AddJobType(jobtype);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالوظيفة بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), jobTypeViewModels);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var jobtype = _mapper.Map<JobType>(jobTypeViewModels);
                    _jobtype.UpdateJobType(jobTypeViewModels.Id, jobtype);
                    _toastNotification.AddSuccessToastMessage("تم تعديل الوظيفة بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), jobTypeViewModels);
            }
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobType = _jobtype.GetJobTypeById((int)id);
            var jobTypeViewModel = _mapper.Map<JobTypeViewModels>(jobType);
            if (jobType == null)
            {
                return NotFound();
            }
            var jobtypeList = _jobtype.GetJobTypes();
            ViewBag.JobTypes = jobtypeList;
            return View("Index", jobTypeViewModel);
        }

        #region Delete

        public  IActionResult Delete(long id)
        {
            _jobtype.RemoveJobType(id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion 


      
    }
}