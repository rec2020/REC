using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IEmployeeRepository
    {

        int AddEmployee(Employee Employee);
        Employee GetEmployeeById(int Id);
        IQueryable<Employee> GetEmployees();
        bool RemoveEmployee(int Id);
        bool UpdateEmployee(int Id, Employee emp);
    }
}
