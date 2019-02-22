using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
   public interface IExpenseRepository
    {
        IQueryable<Expense> GetExpenses();
        Expense GetExpenseById(int id);
        int AddExpense(Expense expense);
        bool UpdateExpense(int id, Expense expense);
        bool RemoveExpense(int id);
    }
}
