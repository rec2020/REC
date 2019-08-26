using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class FinancialPeriodController : Controller
    {
        private readonly IFinancialPeriodRepository _financialPeriod;
        private readonly IFinancialPeriodStatusRepository _status;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public FinancialPeriodController(IToastNotification toastNotification,
            IMapper mapper, IFinancialPeriodRepository financialPeriod, IFinancialPeriodStatusRepository status)
        {
            _mapper = mapper;
            _financialPeriod = financialPeriod;
            _toastNotification = toastNotification;
            _status = status;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, int SearchString)
        {
            var financialPeriodList = _financialPeriod.GetFinancialPeriods();

            if (SearchString >0)
            {
                financialPeriodList = _financialPeriod.GetFinancialPeriods().Where(x => x.Year==SearchString);
            }
            else
            {
                financialPeriodList = _financialPeriod.GetFinancialPeriods();
            }
            ViewBag.FinancialPeriod = financialPeriodList;
            if (financialPeriodList.Count() <= 12) { page = 1; }
            int pageSize = 12;
            return View(await PaginatedList<FinancialPeriod>.CreateAsync(financialPeriodList.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddPost(int year)
        {
            if (year>0)
            {
                _financialPeriod.AddFinancialByYear(year);
                _toastNotification.AddSuccessToastMessage("تم أضافةالفترة المالية بنجاح");
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


        #region CloseFinancialPeriod
        public IActionResult CloseFinancialPeriod(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var financePeriod = _financialPeriod.GetFinancialPeriodById((int)id);
            if (financePeriod != null)
            {
                financePeriod.FinancialPeriodStatusId = (int)EnumHelper.FinancPeriodStatus.CLOSE;
                _financialPeriod.CloseFinancialPeriod(financePeriod.Id, financePeriod);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ActivatedFinancialPeriod 
        public IActionResult ActivatedFinancialPeriod(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var financePeriod = _financialPeriod.GetFinancialPeriodById((int)id);
            if (financePeriod != null)
            {
                financePeriod.FinancialPeriodStatusId = (int)EnumHelper.FinancPeriodStatus.CURRENT;
                _financialPeriod.ActivatedFinancialPeriod(financePeriod.Id, financePeriod);
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}