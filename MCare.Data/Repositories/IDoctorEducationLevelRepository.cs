using System.Linq;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IDoctorEducationLevelRepository
    {
        long AddDoctorEducationLevel(DoctorEducationLevel doctorEducationLevel);
        IQueryable<DoctorEducationLevel> GetDoctorEducationLevels(long doctorId);
        DoctorEducationLevel GetDoctorEducationLevelById(long educationLevelId);
        bool RemoveDoctorEducationLevel(long educationLevelId);
        bool UpdateDoctor(long doctorId, DoctorEducationLevel doctorEducationLevel);
    }
}