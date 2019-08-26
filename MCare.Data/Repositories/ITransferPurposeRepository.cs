using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface ITransferPurposeRepository
    {
        IQueryable<TransferPurpose> GetTransferPurposes();
        TransferPurpose GetTransferPurposeById(int id);
        int AddTransferPurpose(TransferPurpose purpose);
        bool UpdateTransferPurpose(int id, TransferPurpose purpose);
        bool RemoveTransferPurpose(int id);
    }
}
