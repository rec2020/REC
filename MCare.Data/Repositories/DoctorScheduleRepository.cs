using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private NajmetAlraqeeContext _context;

        public DoctorScheduleRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddDoctorEducationLevel(DoctorSchedule doctorSchedule)
        {
            _context.DoctorSchedules.Add(doctorSchedule);
            _context.SaveChanges();

            return doctorSchedule.Id;
        }

        public IQueryable<DoctorSchedule> GetDoctorSchedules(long doctorId)
        {
            return _context.DoctorSchedules.Where(p => p.DoctorId == doctorId);
        }

        public DoctorSchedule GetDoctorScheduleById(long doctorScheduleId)
        {
            return _context.DoctorSchedules.SingleOrDefault(p => p.Id == doctorScheduleId);
        }

        public bool RemoveDoctorSchedule(long doctorScheduleId)
        {
            DoctorSchedule doctorSchedule = GetDoctorScheduleById(doctorScheduleId);
            if (doctorSchedule == null)
                return false;

            _context.Remove(doctorSchedule);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateDoctorSchedule(long doctorScheduleId, ScheduleStatusEnum newStatusId)
        {
            var schedule = GetDoctorScheduleById(doctorScheduleId);
            if (schedule == null)
                return false;

            schedule.ScheduleStatusId = (int) newStatusId;
            _context.SaveChanges();

            return true;
        }

        
    }
}
