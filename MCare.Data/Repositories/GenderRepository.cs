using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class GenderRepository : IGenderRepository
    {

        private NajmetAlraqeeContext _context;

        public GenderRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddGender(Gender gender)
        {
            _context.Genders.Add(gender);
            _context.SaveChanges();

            return gender.Id;
        }

        public Gender GetGender(int genderId)
        {
            return _context.Genders
               .SingleOrDefault(p => p.Id == genderId);
        }

        public IQueryable<Gender> GetGenders()
        {
            return _context.Genders;
        }

        public bool RemoveGender(int genderId)
        {
            Gender gender = GetGender(genderId);
            if (gender == null)
                return false;
            _context.Remove(gender);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateGender(int genderId, Gender gender)
        {

            Gender existgender = GetGender(genderId);
            if (existgender == null)
                return false;

            existgender.Name = gender.Name;
            _context.Update(existgender);
            _context.SaveChanges();

            return true;
        }
    }
}
