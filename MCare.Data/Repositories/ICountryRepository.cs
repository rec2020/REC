using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface ICountryRepository
    {
        IQueryable<Country> GetCountries();
        Country GetById(int id);
        int AddCountry(Country country);
        bool UpdateCountry(int id, Country country);
        bool RemoveCountry(int id);
       
    }
}
