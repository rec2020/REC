using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Helper;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IEmployeeRepository _emp;
        private readonly INationalityRepository _nationality;
        private readonly IGenderRepository _gender;
        private readonly IReligionRepository _religion;
        private readonly ISocialStatusRepository _socialstatus;
        private readonly IForeignAgencyRepository _foreignagency;
        private readonly IJobTypeReository _jobtype;

        public EmployeeController(NajmetAlraqeeContext context, IForeignAgencyRepository foreignagency, IJobTypeReository jobtype, IReligionRepository religion, ISocialStatusRepository socialstatus, IGenderRepository gender, INationalityRepository nationality, IEmployeeRepository emp, IMapper mapper, IToastNotification toastNotification)
        {
            _context = context;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _emp = emp;
            _nationality = nationality;
            _gender = gender;
            _socialstatus = socialstatus;
            _religion = religion;

            _foreignagency = foreignagency;
            _jobtype = jobtype;
        }

        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var employeeList = _emp.GetEmployees();
            if (SearchString != null)
            {
                employeeList = _emp.GetEmployees().Where(x => x.FirstName.Contains(SearchString));
            }
            else
            {
                employeeList = _emp.GetEmployees();
            }
            if (employeeList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var employeePagingList = await PaginatedList<Employee>.CreateAsync(employeeList.AsNoTracking(), page ?? 1, pageSize);
            ViewBag.Employee = employeePagingList;
            return View(employeePagingList);
        }


        #region Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = _emp.GetEmployeeById((int)id);
            //var employeeViewModels = _mapper.Map<EmployeeViewModel>(employee);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            EmployeeViewModel employeeviewmodel = new EmployeeViewModel();
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name");
            ViewBag.GenderId = new SelectList(_gender.GetGenders(), "Id", "Name");
            ViewBag.SocialStatusId = new SelectList(_socialstatus.GetSocialStatuss(), "Id", "Name");
            ViewBag.ReligionId = new SelectList(_religion.GetReligions(), "Id", "Name");
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name"); ;
            //ViewBag.ForeignAgencyId = new SelectList(_foreignagency.GetAgencies(), "Id", "OfficeName"); ;

            var test = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);
            return View(employeeviewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(EmployeeViewModel employeeViewModels)
        {

            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name");
            ViewBag.GenderId = new SelectList(_gender.GetGenders(), "Id", "Name");
            ViewBag.SocialStatusId = new SelectList(_socialstatus.GetSocialStatuss(), "Id", "Name");
            ViewBag.ReligionId = new SelectList(_religion.GetReligions(), "Id", "Name");
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name"); ;
            //ViewBag.ForeignAgencyId = new SelectList(_foreignagency.GetAgencies(), "Id", "OfficeName");

            if (employeeViewModels.JobTypeId == null) { ModelState.AddModelError("", "الرجاء تحديد الوظيفة"); }
            if (employeeViewModels.ReligionId == null) { ModelState.AddModelError("", "الرجاء تحدد الدياتة "); }
            //if (employeeViewModels.ForeignAgencyId == null) { ModelState.AddModelError("", "الرجاء تحديد الوكالة الخارجية"); }
            if (employeeViewModels.NationalityId == null) { ModelState.AddModelError("", "الرجاء تحدد الجنسية"); }
            if (employeeViewModels.GenderId == null) { ModelState.AddModelError("", "الرجاء تحديد الجنس"); }
            if (employeeViewModels.SocialStatusId == null) { ModelState.AddModelError("", "الرجاء تحديد الحالة الاجتماعية "); }

            if (employeeViewModels.Id == 0)
            {
                ModelState.Remove("Id");

                ModelState.Remove("JobTypeId");
                ModelState.Remove("ReligonId");
                //ModelState.Remove("ForeignAgencyId");
                ModelState.Remove("NationalityId");
                ModelState.Remove("GenderId");
                ModelState.Remove("SocialStatusId");

                employeeViewModels.EmployeeStatusId = (int)EnumHelper.EmployeeStatus.New;
                if (ModelState.IsValid)
                {
                    var emp = _mapper.Map<Employee>(employeeViewModels);
                    _emp.AddEmployee(emp);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالموظف بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(employeeViewModels);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var employee = _mapper.Map<Employee>(employeeViewModels);
                    _emp.UpdateEmployee(employeeViewModels.Id, employee);
                    _toastNotification.AddSuccessToastMessage("تم تعديل الموظف بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View("Add", employeeViewModels);
            }
        }
        #endregion

        #region Edit 
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _emp.GetEmployeeById((int)id);
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name", employeeViewModel.NationalityId);
            ViewBag.GenderId = new SelectList(_gender.GetGenders(), "Id", "Name", employeeViewModel.GenderId);
            ViewBag.SocialStatusId = new SelectList(_socialstatus.GetSocialStatuss(), "Id", "Name", employeeViewModel.SocialStatusId);
            ViewBag.ReligionId = new SelectList(_religion.GetReligions(), "Id", "Name", employeeViewModel.ReligionId);
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name", employeeViewModel.JobTypeId); ;
            //ViewBag.ForeignAgencyId = new SelectList(_foreignagency.GetAgencies(), "Id", "OfficeName", employeeViewModel.ForeignAgencyId); ;
            return View("Add", employeeViewModel);
        }
        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            _emp.RemoveEmployee(id);
            _toastNotification.AddSuccessToastMessage("تم حذف الموظف  بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}