using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IDoctorVacationRepository
    {
        IQueryable<DoctorVacation> GetDoctorVacation();
        DoctorVacation GetDoctorVacation(long Id);
        long AddDoctorVacation(DoctorVacation vaction);
        bool UpdateDoctorVacation(long Id, DoctorVacation vaction);
        bool RemoveDoctorVacation(long Id);
    }
}
