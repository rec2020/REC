using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IDelegateReository
    {
        int AddDelegate(UserDelegate deleg);
        UserDelegate GetDelegateById(int Id);
        IQueryable<UserDelegate> GetDelegates();
        bool RemoveDelegate(int Id);
        bool UpdateDelegate(int Id, UserDelegate del);
    }
}
