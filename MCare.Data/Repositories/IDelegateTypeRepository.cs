using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IDelegateTypeRepository
    {

        IQueryable<DelegateType> GetDelegateTypes();
        DelegateType GetDelegateTypeById(int id);
        int AddDelegateType(DelegateType cdelegateType);
        bool UpdateDelegateType(int id, DelegateType delegateType);
        bool RemoveDelegateType(int id);

    }
}
