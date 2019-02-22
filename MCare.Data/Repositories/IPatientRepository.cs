using NajmetAlraqee.Data.Entities;
using System.Linq;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IPatientRepository
    {
        long AddPatient(Patient patient);
        Patient GetPatient(long patientId);
        Patient GetPatientByUserId(string userId);
        IQueryable<Patient> GetPatients();
        bool RemovePatient(long patientId);
        bool UpdatePatient(long patientId, Patient updatedPatient);
    }
}