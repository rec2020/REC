using System.Linq;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IDoctorRepository
    {
        long AddDoctor(Doctor doctor);
        Doctor GetDoctor(long doctorId);
        IQueryable<Doctor> GetDoctors();
        bool RemoveDoctor(long doctorId);
        bool UpdateDoctor(long doctorId, Doctor doctor);
    }
}