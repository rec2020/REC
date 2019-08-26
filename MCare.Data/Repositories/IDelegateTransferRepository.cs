using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IDelegateTransferRepository
    {
        int AddDelegateTransfer(DelegateTransfer agencyTransfer);
        DelegateTransfer GetDelegateTransferById(int Id);
        IQueryable<DelegateTransfer> GetDelegateTransfers();
        bool RemoveDelegateTransfer(int Id);
        bool UpdateDelegateTransfer(int Id, DelegateTransfer agencyTransfer);
    }
}
