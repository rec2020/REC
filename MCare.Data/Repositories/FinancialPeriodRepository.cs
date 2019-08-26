using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;


namespace NajmetAlraqee.Data.Repositories
{
    public class FinancialPeriodRepository : IFinancialPeriodRepository
    {
        private NajmetAlraqeeContext _context;
        public FinancialPeriodRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public bool ActivatedFinancialPeriod(int Id, FinancialPeriod financialperiod)
        {
            var checkIFSomeActive = GetFinancialPeriods().Where(x => x.Year == financialperiod.Year
            && x.FinancialPeriodStatusId==(int)EnumHelper.FinancPeriodStatus.CURRENT).ToList();
            if (checkIFSomeActive.Count()==0) { 
            FinancialPeriod existfinancialperiod = GetFinancialPeriodById(Id);
            if (existfinancialperiod == null)
                return false;
            existfinancialperiod.FinancialPeriodStatusId = financialperiod.FinancialPeriodStatusId;
            _context.Update(existfinancialperiod);
            _context.SaveChanges();
            }
            return true;
        }

        public int AddFinancialByYear(int year)
        {
            FinancialPeriod  obj = new FinancialPeriod();
            for (int month = 1; month <= 12; month++)
            {
                 
                obj.Year = year;
                obj.Month = month;
                var firstday = new DateTime(obj.Year, (int)obj.Month, 1);
                obj.FromData = new DateTime(obj.Year, (int)obj.Month , 1).ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);
                obj.ToDate = firstday.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);
                obj.FinancialPeriodStatusId = (int)EnumHelper.FinancPeriodStatus.OPEN;
                _context.FinancialPeriods.Add(obj);
                _context.SaveChanges();
                obj = new FinancialPeriod();
            }
            
            return obj.Id; 
        }

        public int AddFinancialPeriod(FinancialPeriod financialperiod)
        {
            _context.FinancialPeriods.Add(financialperiod);
            _context.SaveChanges();
            return financialperiod.Id;
        }

        public bool CloseFinancialPeriod(int Id, FinancialPeriod financialperiod)
        {
            FinancialPeriod existfinancialperiod = GetFinancialPeriodById(Id);
            if (existfinancialperiod == null)
                return false;
            existfinancialperiod.FinancialPeriodStatusId = financialperiod.FinancialPeriodStatusId;
            _context.Update(existfinancialperiod);
            _context.SaveChanges();

            return true;

        }

        public FinancialPeriod GetFinancialPeriodById(int Id)
        {
            return _context.FinancialPeriods.Find(Id);
        }

        public IQueryable<FinancialPeriod> GetFinancialPeriods()
        {
            return _context.FinancialPeriods.Include(x=>x.FinancialPeriodStatus).OrderByDescending(x=>x.Year);
        }

        public bool RemoveFinancialPeriod(int Id)
        {
            var type = _context.FinancialPeriods.SingleOrDefault(x => x.Id == Id);
            if (type == null)
                return false;
            _context.FinancialPeriods.Remove(type);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateFinancialPeriod(int Id, FinancialPeriod financialperiod)
        {
            FinancialPeriod existFinancialPeriod = GetFinancialPeriodById(Id);
            if (existFinancialPeriod == null)
                return false;
            existFinancialPeriod.Month = financialperiod.Month;
            existFinancialPeriod.FromData = financialperiod.FromData;
            existFinancialPeriod.ToDate = financialperiod.ToDate;

            _context.Update(existFinancialPeriod);
            _context.SaveChanges();

            return true;
        }



    }
}
