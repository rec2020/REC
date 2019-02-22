using System.Linq;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public interface INationalityRepository
    {
        long AddNationality(Nationality nationality);
        Nationality GetNationality(long NationalityId);
        IQueryable<Nationality> GetNationalities();
        bool RemoveNationality(long NationalityId);
        bool UpdateNationality(long NationalityId, Nationality nationality);
    }
}