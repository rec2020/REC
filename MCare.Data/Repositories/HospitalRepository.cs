using System;
using System.Collections.Generic;
using System.Text;
using NajmetAlraqee.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NajmetAlraqee.Data.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private NajmetAlraqeeContext _context;

        public HospitalRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddHospital(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            _context.SaveChanges();

            return hospital.Id;
        }

        public Hospital GetHospital(long hospitalId)
        {
            return _context.Hospitals
                 .Include("City").Include("Country").Include("HospitalType")
                .SingleOrDefault(p => p.Id == hospitalId);
        }

        public IQueryable<Hospital> GetHospitals()
        {
            return _context.Hospitals.Include("City").Include("Country").Include("HospitalType");
        }

        public bool RemoveHospital(long hospitalId)
        {
            Hospital hospital = GetHospital(hospitalId);
            if (hospital == null)
                return false;

            _context.Remove(hospital);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateHospital(long hospitalId, Hospital hospital)
        {
            Hospital lasthospital = GetHospital(hospitalId);
            if (lasthospital == null)
                return false;

            _context.Update(hospital);
            _context.SaveChanges();

            return true;
        }
    }
}
