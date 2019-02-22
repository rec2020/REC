using NajmetAlraqee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private NajmetAlraqeeContext _context;

        public PatientRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return patient.Id;
        }

        public Patient GetPatient(long patientId)
        {
            return _context.Patients
                .Include("User").Include("Gender").Include("Nationality")
                .SingleOrDefault(p => p.Id == patientId);
        }

        public Patient GetPatientByUserId(string userId)
        {
            return _context.Patients
                .Include("User").Include("Gender").Include("Nationality")
                .SingleOrDefault(p => p.UserId == userId);
        }

        public IQueryable<Patient> GetPatients()
        {
            return _context.Patients
             .Include("User").Include("Gender").Include("Nationality");
        }

        public bool RemovePatient(long patientId)
        {
            Patient patient = GetPatient(patientId);
            if (patient == null)
                return false;

            _context.Remove(patient);
            _context.SaveChanges();

            return true;
        }

        public bool UpdatePatient(long patientId, Patient updatedPatient)
        {
            Patient patient = GetPatient(patientId);
            if (patient == null)
                return false;

            patient.ArabicName = updatedPatient.ArabicName;
            patient.EnglishName = updatedPatient.EnglishName;
            patient.GenderId = updatedPatient.GenderId;
            patient.BirthDate = updatedPatient.BirthDate;
            patient.NationalityId = updatedPatient.NationalityId;

            _context.SaveChanges();
            return true;
        }
    }
}
