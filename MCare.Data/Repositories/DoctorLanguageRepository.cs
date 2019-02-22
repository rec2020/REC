using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class DoctorLanguageRepository : IDoctorLanguageRepository
    {
        private NajmetAlraqeeContext _context;

        public DoctorLanguageRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddDoctorEducationLevel(DoctorLanguage doctorLanguage)
        {
            _context.DoctorLanguages.Add(doctorLanguage);
            _context.SaveChanges();

            return doctorLanguage.Id;
        }

        public IQueryable<DoctorLanguage> GetDoctorLanguages(long doctorId)
        {
            return _context.DoctorLanguages.Where(p => p.DoctorId == doctorId);
        }

        public DoctorLanguage GetLangaugeById(long doctorLanguageId)
        {
            return _context.DoctorLanguages.SingleOrDefault(p => p.Id == doctorLanguageId);
        }

        public bool RemoveDoctorLanguage(long doctorLanguageId)
        {
            DoctorLanguage doctorLanguage = GetLangaugeById(doctorLanguageId);
            if (doctorLanguage == null)
                return false;

            _context.Remove(doctorLanguage);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateDoctor(long doctorId, DoctorLanguage doctorLanguage)
        {
            throw new NotImplementedException();
        }
    }
}
