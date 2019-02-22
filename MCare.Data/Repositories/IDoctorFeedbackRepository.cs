using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IDoctorFeedbackRepository
    {
        long AddFeedback(DoctorFeedback doctorFeedback);
        IQueryable<DoctorFeedback> GetDoctorFeedbacks(long doctorId);
        DoctorFeedback GetFeedbackById(long feedbackId);
        bool HaveRateBefore(long patientId, long doctorId);
    }
}
