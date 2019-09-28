using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class SpecialEmployeeController : Controller
    {
        #region Filed 
      
        private readonly ISpecialEmployeeRepository _emp_spec;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly INationalityRepository _nationality;
       

        #endregion
        public SpecialEmployeeController( INationalityRepository nationality, ISpecialEmployeeRepository emp_spec, IMapper mapper, IToastNotification toastNotification)
        {
            _emp_spec = emp_spec;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _nationality = nationality;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var employeeList = _emp_spec.GetSpecialEmployees();

            if (SearchString != null)
            {
                employeeList = _emp_spec.GetSpecialEmployees().Where(x => x.Name.Contains(SearchString));
            }
            else
            {
                employeeList = _emp_spec.GetSpecialEmployees();
            }
            
            if (employeeList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var specificEmployee = await PaginatedList<SpecialEmployee>.CreateAsync(employeeList.AsNoTracking(), page ?? 1, pageSize);
            ViewBag.SpecialEmployees = specificEmployee;
            return View(specificEmployee);
        }
        #endregion

        #region Details
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var spec_Emp = _emp_spec.GetSpecialEmployeeById((int)id);
            var speEmpViewModels = _mapper.Map<SpecialEmployeeViewModel>(spec_Emp);
            if (speEmpViewModels == null)
            {
                return NotFound();
            }
            return View(speEmpViewModels);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(SpecialEmployeeViewModel specEmployeeViewModel)
        {
            if (specEmployeeViewModel.NationalityId == null) { ModelState.AddModelError("", "الرجاء ادخال جنسية الموظف"); }
            if (specEmployeeViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("NationalityId");
                if (ModelState.IsValid)
                {

                    var specEmp = _mapper.Map<SpecialEmployee>(specEmployeeViewModel);
                    _emp_spec.AddSpecialEmployee(specEmp);
                    _toastNotification.AddSuccessToastMessage("تم أضافة بيانات الموظف بنجاح");
                    return RedirectToAction(nameof(Index));
                }

                return View(specEmployeeViewModel);
            }
            else
            {
                ModelState.Remove("NationalityId");
                if (ModelState.IsValid)
                {
                    var specEmployee = _mapper.Map<SpecialEmployee>(specEmployeeViewModel);
                    _emp_spec.UpdateSpecialEmployee(specEmployeeViewModel.Id, specEmployee);
                    _toastNotification.AddSuccessToastMessage("تم تعديل  بيانات الموظف بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View("Add", specEmployeeViewModel);
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

            var specEmp = _emp_spec.GetSpecialEmployeeById((int)id);
            var specEmployeeViewModel = _mapper.Map<SpecialEmployeeViewModel>(specEmp);
            if (specEmp == null)
            {
                return NotFound();
            }
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name", specEmployeeViewModel.NationalityId);
            return View("Add", specEmployeeViewModel);
        }
        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            _emp_spec.RemoveSpecialEmployee(id);
            _toastNotification.AddSuccessToastMessage("تم حذف  بيانات الموظف  بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}