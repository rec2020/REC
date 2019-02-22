using System.Linq;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public interface ICityRepository
    {
        long AddCity(City city);
        IQueryable<City> GetCities();
        City GetCityById(long id);
        bool RemoveCity(long id);
        bool UpdateCity(long id, City City);
    }
}