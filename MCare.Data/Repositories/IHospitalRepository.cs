using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IHospitalRepository
    {
        IQueryable<Hospital> GetHospitals();
        Hospital GetHospital(long hospitalId);
        long AddHospital(Hospital hospital);
        bool UpdateHospital(long hospitalId, Hospital hospital);
        bool RemoveHospital(long hospitalId);        
    }
}
