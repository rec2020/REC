using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public  interface IFinancialPeriodStatusRepository
    {
        FinancialPeriodStatus GetFinancialPeriodStatusById(int Id);
        IQueryable<FinancialPeriodStatus> GetFinancialPeriodStatus();
    }
}
