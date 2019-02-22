using System.Linq;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public interface ISpecialtyRepository
    {
        long AddSpecialty(Specialty specialty);
        Specialty GetSpecialty(long specialtyId);
        IQueryable<Specialty> GetSpecialtys();
        bool RemoveSpecialty(long specialtyId);
        bool UpdateSpecialty(long specialtyId, Specialty specialty);
    }
}