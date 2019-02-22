using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private NajmetAlraqeeContext _context;

        public SpecialtyRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddSpecialty(Specialty specialty)
        {
            _context.Specialties.Add(specialty);
            _context.SaveChanges();

            return specialty.Id;
        }

        public Specialty GetSpecialty(long specialtyId)
        {
            return _context.Specialties.SingleOrDefault(p => p.Id == specialtyId);
        }

        public IQueryable<Specialty> GetSpecialtys()
        {
            return _context.Specialties;
        }

        public bool RemoveSpecialty(long specialtyId)
        {
            Specialty specialty = GetSpecialty(specialtyId);
            if (specialty == null)
                return false;

            _context.Remove(specialty);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateSpecialty(long specialtyId, Specialty specialty)
        {
            throw new NotImplementedException();
        }
    }
}
