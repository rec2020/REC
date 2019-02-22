using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class NationalityRepository : INationalityRepository
    {
        private NajmetAlraqeeContext _context;

        public NationalityRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddNationality(Nationality nationality)
        {
            _context.Nationalities.Add(nationality);
            _context.SaveChanges();

            return nationality.Id;
        }

        public Nationality GetNationality(long NationalityId)
        {
            return _context.Nationalities                
                .SingleOrDefault(p => p.Id == NationalityId);
        }

        public IQueryable<Nationality> GetNationalities()
        {
            return _context.Nationalities;
        }

        public bool RemoveNationality(long NationalityId)
        {
            Nationality nationality = GetNationality(NationalityId);
            if (nationality == null)
                return false;

            _context.Remove(nationality);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateNationality(long NationalityId, Nationality nationality)
        {
            Nationality nation = GetNationality(NationalityId);
            if (nation == null)
                return false;

            nation.Name = nationality.Name;
            _context.Update(nation);
            _context.SaveChanges();

            return true;
        }
    }
}
