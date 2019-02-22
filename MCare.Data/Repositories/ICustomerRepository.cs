using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface ICustomerRepository
    {

        long AddCustomer(Customer customer);
        Customer GetCustomerById(long Id);
        IQueryable<Customer> GetCustomers();
        bool RemoveCustomer(long Id);
        bool UpdateCustomer(long Id, Customer del);
    }
}
