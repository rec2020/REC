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
        Country GetById(long id);
        long AddCountry(Country country);
        bool UpdateCountry(long id, Country country);
        bool RemoveCountry(long id);
       
    }
}
