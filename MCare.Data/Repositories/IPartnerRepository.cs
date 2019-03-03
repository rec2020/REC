using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IPartnerRepository
    {
        IQueryable<Partner> GetPartners();
        Partner GetPartnerById(int id);
        int AddPartner(Partner partner);
        bool UpdatePartner(int id, Partner partner);
        bool RemovePartner(int id);
    }
}
