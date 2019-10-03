using System;
using System.Collections.Generic;
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
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class DelegatesController : Controller
    {
        #region Filed 
        private readonly NajmetAlraqeeContext _context;
        private readonly IDelegateReository _Delegate;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly INationalityRepository _nationality;
        private readonly IDelegateTypeRepository _delegatetype;
        private readonly IAccountTreeRepository _Acctree;

        #endregion
        public DelegatesController(NajmetAlraqeeContext context,
            INationalityRepository nationality, IAccountTreeRepository Acctree,
            IDelegateReository Delegate, IDelegateTypeRepository delegatetype, IMapper mapper, IToastNotification toastNotification)
        {
            _context = context;
            _Delegate = Delegate;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _nationality = nationality;
            _delegatetype = delegatetype;
            _Acctree = Acctree;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var delegateList = _Delegate.GetDelegates();

            if (SearchString != null)
            {
                delegateList = _Delegate.GetDelegates().Where(x => x.Name.Contains(SearchString));
            }
            else
            {
                delegateList = _Delegate.GetDelegates();
            }
            
            if (delegateList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var delgatepaging = await PaginatedList<UserDelegate>.CreateAsync(delegateList.AsNoTracking(), page ?? 1, pageSize);
            ViewBag.Delegates = delgatepaging;
            return View(delgatepaging);
        }
        #endregion

        #region Details
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delegateEmp = _Delegate.GetDelegateById((int)id);
            var delegateViewModels = _mapper.Map<DelegateViewModel>(delegateEmp);
            if (delegateViewModels == null)
            {
                return NotFound();
            }
            return View(delegateViewModels);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.AccountTreeId = new SelectList(_Acctree.GetAccountTrees(), "Id", "DescriptionAr");
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name");
            ViewBag.DelegateTypeId = new SelectList(_delegatetype.GetDelegateTypes(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(DelegateViewModel delegateViewModels)
        {
            if (delegateViewModels.NationalityId == null) { ModelState.AddModelError("", "الرجاء ادخال جنسية المندوب"); }
            if (delegateViewModels.DelegateTypeId == null) { ModelState.AddModelError("", "الرجاء ادخال نوع المندوب"); }
            ViewBag.AccountTreeId = new SelectList(_Acctree.GetAccountTrees(), "Id", "DescriptionAr");
            if (delegateViewModels.AccountTreeId == null) { ModelState.AddModelError("", "الرجاء تحدد رقم الحساب في الشجرة"); }
            if (delegateViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("DelegateTypeId");
                ModelState.Remove("NationalityId");
                ModelState.Remove("AccountTreeId");
                if (ModelState.IsValid)
                {

                    var delegateEmp = _mapper.Map<UserDelegate>(delegateViewModels);
                    _Delegate.AddDelegate(delegateEmp);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالمندوب بنجاح");
                    return RedirectToAction(nameof(Index));
                }

                return View(delegateViewModels);
            }
            else
            {
                ModelState.Remove("DelegateTypeId");
                ModelState.Remove("AccountTreeId");
                ModelState.Remove("NationalityId");
                if (ModelState.IsValid)
                {
                    var Delegate = _mapper.Map<UserDelegate>(delegateViewModels);
                    _Delegate.UpdateDelegate(delegateViewModels.Id, Delegate);
                    _toastNotification.AddSuccessToastMessage("تم تعديل المندوب بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View("Add", delegateViewModels);
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

            var delegateEmp = _Delegate.GetDelegateById((int)id);
            var DelegateViewModel = _mapper.Map<DelegateViewModel>(delegateEmp);
            if (delegateEmp == null)
            {
                return NotFound();
            }
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name", DelegateViewModel.NationalityId);
            ViewBag.DelegateTypeId = new SelectList(_delegatetype.GetDelegateTypes(), "Id", "Name", DelegateViewModel.DelegateTypeId);
            ViewBag.AccountTreeId = new SelectList(_Acctree.GetAccountTrees(), "Id", "DescriptionAr", DelegateViewModel.AccountTreeId);
            return View("Add", DelegateViewModel);
        }
        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            _Delegate.RemoveDelegate(id);
            _toastNotification.AddSuccessToastMessage("تم حذف المندوب  بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion


   
    }
}