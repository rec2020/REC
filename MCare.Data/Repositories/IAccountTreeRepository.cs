using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IAccountTreeRepository 
    {
        int AddAccountTree(AccountTree accTree);
        AccountTree GetAccountTreeById(int Id);
        IQueryable<AccountTree> GetAccountTrees();
        bool RemoveAccountTree(int Id);
        bool UpdateAccountTree(int Id, AccountTree accTree);
    }
}
