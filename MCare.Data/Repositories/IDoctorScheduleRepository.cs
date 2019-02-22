using System.Linq;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Constants;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IDoctorScheduleRepository
    {
        long AddDoctorEducationLevel(DoctorSchedule doctorSchedule);
        DoctorSchedule GetDoctorScheduleById(long doctorScheduleId);
        IQueryable<DoctorSchedule> GetDoctorSchedules(long doctorId);
        bool RemoveDoctorSchedule(long doctorScheduleId);
        bool UpdateDoctorSchedule(long doctorScheduleId, ScheduleStatusEnum newStatusId);
    }
}