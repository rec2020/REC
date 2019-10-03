﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class ForeignAgencyTransferRepository : IForeignAgencyTransferRepository
    {

        private NajmetAlraqeeContext _context;

        public ForeignAgencyTransferRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddForeignAgencyTransfer(ForeignAgencyTransfer agencyTransfer)
        {
            // Add Qaid First 
            RecruitmentQaid qaid = new RecruitmentQaid
            {
                QaidDate = DateTime.UtcNow.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                StatusId = (int)EnumHelper.RecruitmentQaidStatus.Open
            };
            var getCurrentFinancialPeriod = _context.FinancialPeriods.Where(x => x.FinancialPeriodStatusId == (int)EnumHelper.FinancPeriodStatus.CURRENT).SingleOrDefault();
            if (getCurrentFinancialPeriod != null)
            {
                qaid.FinancialPeriodId = getCurrentFinancialPeriod.Id;
            }
            qaid.TypeId = (int)EnumHelper.RecruitmentQaidTypes.Transfer;
            _context.RecruitmentQaids.Add(qaid);
            _context.SaveChanges();


            //snadReceipt.VAT = 0;
            var getCurrentFinancialPeriodrec = _context.FinancialPeriods.Where(x => x.FinancialPeriodStatusId == (int)EnumHelper.FinancPeriodStatus.CURRENT).SingleOrDefault();
            if (getCurrentFinancialPeriodrec != null)
            {
                agencyTransfer.FinancialPeriodId = getCurrentFinancialPeriodrec.Id;
            }
            agencyTransfer.QaidNo = qaid.Id;
            
            _context.ForeignAgencyTransfers.Add(agencyTransfer);
            _context.SaveChanges();

            //
            var existforagency = _context.ForeignAgencies.SingleOrDefault(x => x.Id == agencyTransfer.ForeignAgencyId);
            existforagency.TransferAmount = existforagency.TransferAmount + agencyTransfer.Amount;
            _context.Update(existforagency);
            _context.SaveChanges();

            return agencyTransfer.Id;
        }

        public ForeignAgencyTransfer GetForeignAgencyTransferById(int Id)
        {
            return _context.ForeignAgencyTransfers.Include(x => x.ForeignAgency).Include(x => x.PaymentMethod)
                .Include(x => x.Purpose).Include(x=>x.TransferBank).Include(x => x.Currency)
              .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ForeignAgencyTransfer> GetForeignAgencyTransfers()
        {
            return _context.ForeignAgencyTransfers.Include(x=>x.ForeignAgency).Include(x=>x.PaymentMethod)
                .Include(x => x.TransferBank).Include(x=>x.Currency)
                .Include(x=>x.Purpose);
        }

        public bool RemoveForeignAgencyTransfer(int Id)
        {
            ForeignAgencyTransfer agency = GetForeignAgencyTransferById(Id);
            if (agency == null)
                return false;
            _context.Remove(agency);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateForeignAgencyTransfer(int Id, ForeignAgencyTransfer agencyTransfer)
        {
            ForeignAgencyTransfer existagencyTransfer = GetForeignAgencyTransferById(Id);
            if (existagencyTransfer == null)
                return false;
            existagencyTransfer.ForeignAgencyId = agencyTransfer.ForeignAgencyId;
            existagencyTransfer.Amount = agencyTransfer.Amount;
            existagencyTransfer.CurrencyId = agencyTransfer.CurrencyId;
            existagencyTransfer.Notes = agencyTransfer.Notes;
            existagencyTransfer.PaymentMethodId = agencyTransfer.PaymentMethodId;
            existagencyTransfer.PurposeId = agencyTransfer.PurposeId;
            existagencyTransfer.TransferBankId = agencyTransfer.TransferBankId;
            existagencyTransfer.TransferDate = agencyTransfer.TransferDate;
            _context.Update(existagencyTransfer);
            _context.SaveChanges();

            return true;
        }
    }
}
