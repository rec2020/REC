using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IAccountClassificationTypeRepository
    {
        AccountClassificationType GetAccountClassificationTypeById(int Id);
        IQueryable<AccountClassificationType> GetAccountClassificationTypes();
       
    }
}
