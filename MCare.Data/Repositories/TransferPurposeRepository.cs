using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class TransferPurposeRepository : ITransferPurposeRepository
    {

        private NajmetAlraqeeContext _context;

        public TransferPurposeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddTransferPurpose(TransferPurpose purpose)
        {
            throw new NotImplementedException();
        }

        public TransferPurpose GetTransferPurposeById(int id)
        {
            return _context.TransferPurposes.Find(id);
        }

        public IQueryable<TransferPurpose> GetTransferPurposes()
        {
            return _context.TransferPurposes;
        }

        public bool RemoveTransferPurpose(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTransferPurpose(int id, TransferPurpose purpose)
        {
            throw new NotImplementedException();
        }
    }
}
