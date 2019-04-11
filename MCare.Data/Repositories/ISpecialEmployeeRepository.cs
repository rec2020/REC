using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
   public  interface ISpecialEmployeeRepository
    {
        int AddSpecialEmployee(SpecialEmployee specEmp);
        SpecialEmployee GetSpecialEmployeeById(int Id);
        IQueryable<SpecialEmployee> GetSpecialEmployees();
        bool RemoveSpecialEmployee(int Id);
        bool UpdateSpecialEmployee(int Id, SpecialEmployee specEmp);
    }
}
