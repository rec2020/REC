using System.Linq;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public interface ICityRepository
    {
        int AddCity(City city);
        IQueryable<City> GetCities();
        City GetCityById(int id);
        bool RemoveCity(int id);
        bool UpdateCity(int id, City City);
    }
}