using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IAccountClassificationRepository
    {
        int AddAccountClassification(AccountClassification deleg);
        AccountClassification GetAccountClassificationById(int Id);
        IQueryable<AccountClassification> GetAccountClassifications();
        bool RemoveAccountClassification(int Id);
        bool UpdateAccountClassification(int Id, AccountClassification contract);
        
    }
}
