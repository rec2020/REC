using System.Linq;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IDoctorLanguageRepository
    {
        long AddDoctorEducationLevel(DoctorLanguage doctorLanguage);
        IQueryable<DoctorLanguage> GetDoctorLanguages(long doctorId);
        DoctorLanguage GetLangaugeById(long doctorLanguageId);
        bool RemoveDoctorLanguage(long doctorLanguageId);
        bool UpdateDoctor(long doctorId, DoctorLanguage doctorLanguage);
    }
}