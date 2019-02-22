using System.Linq;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IDoctorSpecialtyRepository
    {
        long AddDoctorSpecialty(DoctorSpecialty doctorSpecialty);
        IQueryable<DoctorSpecialty> GetDoctorSpecialties(long doctorId);
        DoctorSpecialty GetDoctorSpecialtyById(long doctorSpecialtyId);
        bool RemoveDoctorSpecialty(long doctorSpecialtyId);
        bool UpdateDoctorSpecialty(long doctorId, DoctorSpecialty doctorSpecialty);
    }
}