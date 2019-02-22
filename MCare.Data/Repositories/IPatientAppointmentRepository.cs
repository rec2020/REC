using System.Linq;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IPatientAppointmentRepository
    {
        long AddPatientAppointment(PatientAppointment patientAppointment);
        PatientAppointment GetPatientAppointment(long patientAppointmentId);
        IQueryable<PatientAppointment> GetPatientAppointments(long patientId);

        IQueryable<PatientAppointment> GetAllPatientAppointment();
        bool RemovePatientAppointment(long patientAppointmentId);
        bool CancelPatientAppointment(long patientAppointmentId);
    }
}