using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {

        private NajmetAlraqeeContext _context;

        public ExpenseRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return expense.Id;
        }

        public IQueryable<Expense> GetExpenses()
        {
            return _context.Expenses;
        }

        public Expense GetExpenseById(int id)
        {
            return _context.Expenses.Find(id);
        }

        public bool RemoveExpense(int id)
        {
            var expense = _context.Expenses.SingleOrDefault(x => x.Id == id);
            if (expense == null)
                return false;

            _context.Expenses.Remove(expense);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateExpense(int id, Expense expense)
        {
           Expense existexpense = GetExpenseById(id);
            if (existexpense == null)
                return false;

            existexpense.Name = expense.Name;
            existexpense.Code = expense.Code;
            existexpense.AccountNumber = expense.AccountNumber;
            existexpense.PartnerCode = expense.PartnerCode;

            _context.Update(existexpense);
            _context.SaveChanges();

            return true;
        }
    }
}
