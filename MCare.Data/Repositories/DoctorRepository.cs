using NajmetAlraqee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private NajmetAlraqeeContext _context;

        public DoctorRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return doctor.Id;
        }

        public Doctor GetDoctor(long doctorId)
        {
            return _context.Doctors
                .Include("User").Include("Hospital").Include("Gender").Include("Nationality")
                .Include("DoctorLanguages.Language")
                .Include("DoctorEducationLevels.EducationLevel")
                .Include("DoctorSpecialtys.Specialty")
                .Include("DoctorSchedules.ScheduleStatus")
                .SingleOrDefault(p => p.Id == doctorId);
        }

        public IQueryable<Doctor> GetDoctors()
        {
            return _context.Doctors
                .Include("User").Include("Hospital").Include("Gender").Include("Nationality")
                .Include("DoctorLanguages.Language")
                .Include("DoctorEducationLevels.EducationLevel")
                .Include("DoctorSpecialtys.Specialty")
                .Include("DoctorSchedules.ScheduleStatus");
        }

        public bool RemoveDoctor(long doctorId)
        {
            Doctor doctor = GetDoctor(doctorId);
            if (doctor == null)
                return false;

            _context.Remove(doctor);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateDoctor(long doctorId, Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
