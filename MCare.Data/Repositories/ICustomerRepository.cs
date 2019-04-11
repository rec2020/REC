using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface ICustomerRepository
    {

        int AddCustomer(Customer customer);
        Customer GetCustomerById(int Id);
        IQueryable<Customer> GetCustomers();
        bool RemoveCustomer(int Id);
        bool UpdateCustomer(int  Id, Customer cus);
        bool ActivationCustomer(int Id, Customer cust);
    }
}
