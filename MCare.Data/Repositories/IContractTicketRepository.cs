using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IContractTicketRepository
    {
        int AddContractTicket(ContractTicket deleg);
        ContractTicket GetContractTicketById(int Id);
        IQueryable<ContractTicket> GetContractTickets();
        bool RemoveContractTicket(int Id);
        bool UpdateContractTicket(int Id, ContractTicket contractTicket);
        bool ApprovedTicket(int Id, ContractTicket ticket);
    }
}
