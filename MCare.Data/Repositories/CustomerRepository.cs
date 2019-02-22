using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {


        private NajmetAlraqeeContext _context;

        public CustomerRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public long AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer.Id;
        }

        public Customer GetCustomerById(long Id)
        {
            return _context.Customers
                .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public bool RemoveCustomer(long Id)
        {
            Customer customer = GetCustomerById(Id);
            if (customer == null)
                return false;

            _context.Remove(customer);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateCustomer(long Id, Customer customer)
        {
            Customer existcustomer = GetCustomerById(Id);
            if (existcustomer == null)
                return false;
            existcustomer.FirstName = customer.FirstName;
            existcustomer.MiddleName = customer.MiddleName;
            existcustomer.LastName = customer.LastName;
            _context.Update(existcustomer);
            _context.SaveChanges();

            return true;
        }
    }
}
