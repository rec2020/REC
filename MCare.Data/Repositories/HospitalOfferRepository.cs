using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace NajmetAlraqee.Data.Repositories
{
    public class HospitalOfferRepository : IHospitalOfferRepository
    {
        private NajmetAlraqeeContext _context;

        public HospitalOfferRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddOffer(HospitalOffer hospitalOffer)
        {
            _context.HospitalOffers.Add(hospitalOffer);
            _context.SaveChanges();

            return hospitalOffer.Id;
        }

        public HospitalOffer GetOffer(long id)
        {
            return _context.HospitalOffers
                 .Include("Hospital").Include("Hospital.Country").Include("Hospital.City")
                .SingleOrDefault(p => p.Id == id);
        }

        public IQueryable<HospitalOffer> GetOffers()
        {
            return _context.HospitalOffers;
        }
        public bool RemoveHospitalOffer(long hospitalofferId)
        {
            HospitalOffer hospitaloffer = GetOffer(hospitalofferId);
            if (hospitaloffer == null)
                return false;

            _context.Remove(hospitaloffer);
            _context.SaveChanges();

            return true;
        }
    }
}
