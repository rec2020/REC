using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
   public interface IBankDetailRepository
    {
        int AddBankDetail(BankDetail detail);
        BankDetail GetBankDetailById(int Id);
        IQueryable<BankDetail> GetBankDetails();
        bool RemoveBankDetail(int Id);
        bool UpdateBankDetail(int Id, BankDetail detail);
    }
}
