using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private NajmetAlraqeeContext _context;

        public CountryRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();

            return country.Id;
        }

        public Country GetById(long id)
        {
            return _context.Countries.Find(id);
        }

        public IQueryable<Country> GetCountries()
        {
            return _context.Countries;
        }
       
        public bool RemoveCountry(long id)
        {
            var country = _context.Countries.SingleOrDefault(x => x.Id == id);
            if (country == null)
                return false;

            _context.Countries.Remove(country);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCountry(long id, Country country)
        {
            throw new NotImplementedException();
        }
    }
}
