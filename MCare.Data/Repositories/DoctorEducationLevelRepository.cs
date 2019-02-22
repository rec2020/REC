using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class DoctorEducationLevelRepository : IDoctorEducationLevelRepository
    {
        private NajmetAlraqeeContext _context;

        public DoctorEducationLevelRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddDoctorEducationLevel(DoctorEducationLevel doctorEducationLevel)
        {
            _context.DoctorEducationLevels.Add(doctorEducationLevel);
            _context.SaveChanges();

            return doctorEducationLevel.Id;
        }

        public DoctorEducationLevel GetDoctorEducationLevelById(long educationLevelId)
        {
            return _context.DoctorEducationLevels.SingleOrDefault(p => p.Id == educationLevelId);
        }

        public IQueryable<DoctorEducationLevel> GetDoctorEducationLevels(long doctorId)
        {
            return _context.DoctorEducationLevels.Where(p => p.DoctorId == doctorId);
        }

        public bool RemoveDoctorEducationLevel(long educationLevelId)
        {
            DoctorEducationLevel doctorEducationLevel = GetDoctorEducationLevelById(educationLevelId);
            if (doctorEducationLevel == null)
                return false;

            _context.Remove(doctorEducationLevel);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateDoctor(long doctorId, DoctorEducationLevel doctorEducationLevel)
        {
            throw new NotImplementedException();
        }
    }
}
