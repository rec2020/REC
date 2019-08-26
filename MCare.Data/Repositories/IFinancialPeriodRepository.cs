using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IFinancialPeriodRepository
    {
        int AddFinancialPeriod(FinancialPeriod financialperiod);
        int AddFinancialByYear(int year);
        FinancialPeriod GetFinancialPeriodById(int Id);
        IQueryable<FinancialPeriod> GetFinancialPeriods();
        bool RemoveFinancialPeriod(int Id);
        bool UpdateFinancialPeriod(int Id, FinancialPeriod financialperiod);
        bool CloseFinancialPeriod(int Id, FinancialPeriod financialperiod);
        bool ActivatedFinancialPeriod(int Id, FinancialPeriod financialperiod);
    }
}
