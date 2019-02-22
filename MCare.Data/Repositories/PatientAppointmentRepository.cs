using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class PatientAppointmentRepository : IPatientAppointmentRepository
    {
        private NajmetAlraqeeContext _context;

        public PatientAppointmentRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddPatientAppointment(PatientAppointment patientAppointment)
        {
            _context.PatientAppointments.Add(patientAppointment);
            _context.SaveChanges();

            return patientAppointment.Id;
        }

        public PatientAppointment GetPatientAppointment(long patientAppointmentId)
        {
            return _context.PatientAppointments
                .Include("Patient").Include("Gender")
                .Include("DoctorSchedule.Doctor")
                .Include("DoctorSchedule.Doctor.Hospital").Include("DoctorSchedule.Doctor.Gender").Include("DoctorSchedule.Doctor.Nationality")
                .Include("DoctorSchedule.ScheduleStatus")    
                .Include("AppointementStatus")
                .SingleOrDefault(p => p.Id == patientAppointmentId);
        }

        public IQueryable<PatientAppointment> GetPatientAppointments(long patientId)
        {
            return _context.PatientAppointments
                .Include("Patient").Include("Gender")
                .Include("DoctorSchedule.Doctor")
                .Include("DoctorSchedule.Doctor.Hospital").Include("DoctorSchedule.Doctor.Gender").Include("DoctorSchedule.Doctor.Nationality")
                .Include("DoctorSchedule.ScheduleStatus")
                .Include("AppointementStatus")
                .Where(p => p.PatientId == patientId);
        }
        public IQueryable<PatientAppointment> GetAllPatientAppointment()
        {
            return _context.PatientAppointments
                   .Include("Patient").Include("Gender")
                   .Include("DoctorSchedule.Doctor")
                   .Include("DoctorSchedule.Doctor.Hospital").Include("DoctorSchedule.Doctor.Gender").Include("DoctorSchedule.Doctor.Nationality")
                   .Include("DoctorSchedule.ScheduleStatus")
                   .Include("AppointementStatus");
        }
        public bool RemovePatientAppointment(long patientAppointmentId)
        {
            PatientAppointment patientAppointment = GetPatientAppointment(patientAppointmentId);
            if (patientAppointment == null)
                return false;

            _context.Remove(patientAppointment);
            _context.SaveChanges();

            return true;
        }

        public bool CancelPatientAppointment(long patientAppointmentId)
        {
            PatientAppointment patientAppointment = GetPatientAppointment(patientAppointmentId);
            if (patientAppointment == null)
                return false;

            patientAppointment.AppointementStatusId = (int)AppointmentStatusEnum.Cancled;

            _context.SaveChanges();

            return true;
        }
    }
}
