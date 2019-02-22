using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IHospitalOfferRepository
    {
        long AddOffer(HospitalOffer hospitalOffer);
        IQueryable<HospitalOffer> GetOffers();
        HospitalOffer GetOffer(long id);
       bool RemoveHospitalOffer(long hospitalofferId);
    }
}
