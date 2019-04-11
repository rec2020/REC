using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class ContractHistoryRepository : IContractHistoryRepository
    {
        private NajmetAlraqeeContext _context;

        public ContractHistoryRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddContractHistory(ContractHistory history)
        {
            history.ActionDate = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);
            _context.ContractHistories.Add(history);
            _context.SaveChanges();
            return history.Id;
        }

        public ContractHistory GetContractHistoryById(int Id)
        {
            return _context.ContractHistories.Include(x => x.ContractStatus)
               .Include(x => x.Action)
              .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ContractHistory> GetContractHistorys()
        {
            return _context.ContractHistories.Include(x=>x.ContractStatus)
                .Include(x => x.Action);

        }

        public bool RemoveContractHistory(int Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContractHistory(int Id, ContractHistory contractHistory)
        {
            throw new NotImplementedException();
        }
    }
}
