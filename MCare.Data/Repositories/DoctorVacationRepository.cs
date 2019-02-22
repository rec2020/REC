using NajmetAlraqee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public  class DoctorVacationRepository : IDoctorVacationRepository
    {
        private NajmetAlraqeeContext _context;

        public DoctorVacationRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public long AddDoctorVacation(DoctorVacation vacation)
        {
            _context.DoctorVacations.Add(vacation);
            _context.SaveChanges();
            return vacation.Id;
        }

        public DoctorVacation GetDoctorVacation(long id)
        {
            return _context.DoctorVacations
                .Include(d => d.Doctor).Include("Hospital").Include("VacationStatus").Include("VacationType")
                .SingleOrDefault(p => p.Id == id);
        }

        public IQueryable<DoctorVacation> GetDoctorVacation()
        {
            return _context.DoctorVacations.Include(d => d.Doctor).Include("Hospital").Include("VacationStatus").Include("VacationType");
        }

        public bool RemoveDoctorVacation(long Id)
        {
            DoctorVacation vacation = GetDoctorVacation(Id);
            if (vacation == null)
                return false;
            _context.Remove(vacation);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateDoctorVacation(long vacationId, DoctorVacation vacation)
        {
            DoctorVacation lastvaction = GetDoctorVacation(vacationId);
            if (lastvaction == null)
                return false;
            _context.Update(vacation);
            _context.SaveChanges();
            return true;
        }
    }
}
