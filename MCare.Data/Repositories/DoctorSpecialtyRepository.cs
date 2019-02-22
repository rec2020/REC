using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class DoctorSpecialtyRepository : IDoctorSpecialtyRepository
    {
        private NajmetAlraqeeContext _context;

        public DoctorSpecialtyRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddDoctorSpecialty(DoctorSpecialty doctorSpecialty)
        {
            _context.DoctorSpecialties.Add(doctorSpecialty);
            _context.SaveChanges();

            return doctorSpecialty.Id;
        }

        public IQueryable<DoctorSpecialty> GetDoctorSpecialties(long doctorId)
        {
            return _context.DoctorSpecialties.Where(p => p.DoctorId == doctorId);
        }

        public DoctorSpecialty GetDoctorSpecialtyById(long doctorSpecialtyId)
        {
            return _context.DoctorSpecialties.SingleOrDefault(p => p.Id == doctorSpecialtyId);
        }

        public bool RemoveDoctorSpecialty(long doctorSpecialtyId)
        {
            DoctorSpecialty doctorSpecialty = GetDoctorSpecialtyById(doctorSpecialtyId);
            if (doctorSpecialty == null)
                return false;

            _context.Remove(doctorSpecialty);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateDoctorSpecialty(long doctorId, DoctorSpecialty doctorSpecialty)
        {
            throw new NotImplementedException();
        }
    }
}
