using NajmetAlraqee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private NajmetAlraqeeContext _context;

        public CityRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();

            return city.Id;
        }

        public City GetCityById(int id)
        {
            return _context.Cities                
                .Find(id);
        }

        public IQueryable<City> GetCities()
        {
            return _context.Cities
                .Include("Country");
        }

        public bool RemoveCity(int id)
        {
            City city = GetCityById(id);
            if (city == null)
                return false;

            _context.Remove(city);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateCity(int id, City City)
        {
            City existCity = GetCityById(id);
            if (existCity == null)
                return false;

            existCity.Name = City.Name;
            existCity.CountryId = City.CountryId;
            _context.Update(existCity);
            _context.SaveChanges();

            return true;
        }
    }
}
