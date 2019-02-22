using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace NajmetAlraqee.Data.Repositories
{
    public class DoctorFeedbackRepository : IDoctorFeedbackRepository
    {
        private NajmetAlraqeeContext _context;

        public DoctorFeedbackRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddFeedback(DoctorFeedback doctorFeedback)
        {
            _context.DoctorFeedbacks.Add(doctorFeedback);
            _context.SaveChanges();

            return doctorFeedback.Id;
        }

        public IQueryable<DoctorFeedback> GetDoctorFeedbacks(long doctorId)
        {
            return _context.DoctorFeedbacks
                .Include("Patient").Include("Doctor")
                .Where(p => p.DoctorId == doctorId);
        }

        public DoctorFeedback GetFeedbackById(long feedbackId)
        {
            return _context.DoctorFeedbacks.Find(feedbackId);
        }

        public bool HaveRateBefore(long patientId, long doctorId)
        {
            return _context.DoctorFeedbacks.Any(p =>
                p.PatientId == patientId && p.DoctorId == doctorId);
        }
    }
}
