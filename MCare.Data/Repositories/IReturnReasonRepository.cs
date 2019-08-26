using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IReturnReasonRepository
    {
        IQueryable<ReturnReason> GetReturnReasons();
        ReturnReason GetReturnReasonById(int id);
        int AddReturnReason(ReturnReason reason);
        bool UpdateReturnReason(int id, ReturnReason reason);
        bool RemoveReturnReason(int id);
    }
}
