using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IForeignAgencyTransferRepository
    {
        int AddForeignAgencyTransfer(ForeignAgencyTransfer agencyTransfer);
        ForeignAgencyTransfer GetForeignAgencyTransferById(int Id);
        IQueryable<ForeignAgencyTransfer> GetForeignAgencyTransfers();
        bool RemoveForeignAgencyTransfer(int Id);
        bool UpdateForeignAgencyTransfer(int Id, ForeignAgencyTransfer agencyTransfer);
        
    }
}
