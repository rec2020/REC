using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {

        private NajmetAlraqeeContext _context;

        public PartnerRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddPartner(Partner partner)
        {
            _context.Partners.Add(partner);
            _context.SaveChanges();

            return partner.Id;
        }

        public Partner GetPartnerById(int id)
        {
            return _context.Partners
               .SingleOrDefault(p => p.Id == id);
        }

        public IQueryable<Partner> GetPartners()
        {
            return _context.Partners;
        }

        public bool RemovePartner(int id)
        {
            Partner partner = GetPartnerById(id);
            if (partner == null)
                return false;

            _context.Remove(partner);
            _context.SaveChanges();

            return true;
        }

        public bool UpdatePartner(int id, Partner partner)
        {
            Partner existPartner = GetPartnerById(id);
            if (existPartner == null)
                return false;
            existPartner.Name = partner.Name;
            existPartner.Percentage = partner.Percentage;
            existPartner.Deserved = partner.Deserved;
            existPartner.Remiander = partner.Remiander;
            existPartner.Transfer = partner.Transfer;
            existPartner.Expenses = partner.Expenses;
            _context.Update(existPartner);
            _context.SaveChanges();

            return true;
        }
    }
}
