using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class ReligionRepository : IReligionRepository
    {
        private NajmetAlraqeeContext _context;

        public ReligionRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddReligion(Religion religion)
        {
            _context.Religions.Add(religion);
            _context.SaveChanges();

            return religion.Id;
        }

        public Religion GetReligion(int religionId)
        {
            return _context.Religions
              .SingleOrDefault(p => p.Id == religionId);
        }

        public IQueryable<Religion> GetReligions()
        {
            return _context.Religions;
        }

        public bool RemoveReligion(int religionId)
        {
            Religion religion = GetReligion(religionId);
            if (religion == null)
                return false;
            _context.Remove(religion);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateReligion(int religionId, Religion religion)
        {
            Religion existreligion = GetReligion(religionId);
            if (existreligion == null)
                return false;

            existreligion.Name = religion.Name;
            _context.Update(existreligion);
            _context.SaveChanges();

            return true;
        }
    }
}
