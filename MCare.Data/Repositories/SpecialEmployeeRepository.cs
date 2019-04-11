using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class SpecialEmployeeRepository : ISpecialEmployeeRepository
    {
        private NajmetAlraqeeContext _context;

        public SpecialEmployeeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddSpecialEmployee(SpecialEmployee specEmp)
        {
            _context.SpecialEmployees.Add(specEmp);
            _context.SaveChanges();
            return specEmp.Id;
        }

        public SpecialEmployee GetSpecialEmployeeById(int Id)
        {
            return _context.SpecialEmployees.Include(x => x.Nationality)
              .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<SpecialEmployee> GetSpecialEmployees()
        {
            return _context.SpecialEmployees.Include(x => x.Nationality);
        }

        public bool RemoveSpecialEmployee(int Id)
        {
            SpecialEmployee specEmployee = GetSpecialEmployeeById(Id);
            if (specEmployee == null)
                return false;
            _context.Remove(specEmployee);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateSpecialEmployee(int Id, SpecialEmployee specEmp)
        {
            SpecialEmployee existSpecialEmployee = GetSpecialEmployeeById(Id);
            if (existSpecialEmployee == null)
                return false;
            existSpecialEmployee.Name = specEmp.Name;
            existSpecialEmployee.NationalityId = specEmp.NationalityId;
            existSpecialEmployee.PassportNo = specEmp.PassportNo;

            _context.Update(existSpecialEmployee);
            _context.SaveChanges();

            return true;
        }
    }
}
