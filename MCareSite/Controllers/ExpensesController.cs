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
    public class ExpensesController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly IExpenseRepository _expense;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public ExpensesController(NajmetAlraqeeContext context, IExpenseRepository expense, IMapper mapper, IToastNotification toastNotification)
        {
            _context = context;
            _expense = expense;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        #region Index 
        public IActionResult Index(int? page)
        {
            var expenses = _expense.GetExpenses();
            ViewBag.Expenses = expenses;
            //if (nationality.Count() <= 10) { page = 1; }
            //int pageSize = 10;
            return View();
        }
        #endregion
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(ExpenseViewModel expenseViewModel)
        {
            var expensesList = _expense.GetExpenses();
            ViewBag.expenses = expensesList;
            if (expenseViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var expense = _mapper.Map<Expense>(expenseViewModel);
                    _expense.AddExpense(expense);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالمصروف بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), expenseViewModel);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var expensedetail = _mapper.Map<Expense>(expenseViewModel);
                    _expense.UpdateExpense(expenseViewModel.Id, expensedetail);
                    _toastNotification.AddSuccessToastMessage("تم تعديل البنك بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), expenseViewModel);
            }

        }


        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense= _expense.GetExpenseById((int)id);
            var expenseViewModel = _mapper.Map<ExpenseViewModel>(expense);
            if (expense == null)
            {
                return NotFound();
            }
            var expensesList = _expense.GetExpenses();
            ViewBag.expenses = expensesList;
            return View("Index", expenseViewModel);
        }
        #region Delete

        public IActionResult Delete(int id)
        {
            _expense.RemoveExpense(id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion 

    }
}