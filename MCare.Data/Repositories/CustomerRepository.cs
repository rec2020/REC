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
        public int AddCustomer(Customer customer)
        {
            var customertype = _context.CurrencyTypes.SingleOrDefault(x => x.Id == customer.CustomerTypeId);
            if (customertype != null) { customer.CustomerTypeName = customertype.Name; }

            var delegateuser = _context.UserDelegates.SingleOrDefault(x => x.Id == customer.UserDelegateId);
            if (delegateuser != null) { customer.UserDelegateName = delegateuser.Name; }
            customer.Name = customer.FirstName + "  " + customer.MiddleName + "  " + customer.LastName;
            customer.IsActive = true;
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer.Id;
        }

        public Customer GetCustomerById(int Id)
        {
            return _context.Customers
                .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public bool RemoveCustomer(int Id)
        {
            Customer customer = GetCustomerById(Id);
            if (customer == null)
                return false;

            _context.Remove(customer);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateCustomer(int Id, Customer customer)
        {

            Customer existcustomer = GetCustomerById(Id);
            if (existcustomer == null)
                return false;
            existcustomer.FirstName = customer.FirstName;
            existcustomer.MiddleName = customer.MiddleName;
            existcustomer.LastName = customer.LastName;
            existcustomer.Address = customer.Address;
            existcustomer.FamilyImage = customer.FamilyImage;
            existcustomer.IdentiyImage = customer.IdentiyImage;
            existcustomer.IdentityNo = customer.IdentityNo;
            existcustomer.IsActive = customer.IsActive;
            existcustomer.SecondPhone = customer.IdentiyImage;
            existcustomer.FirstPhone = customer.IdentityNo;
            existcustomer.CustomerTypeId = customer.CustomerTypeId;
            existcustomer.UserDelegateId = customer.UserDelegateId;

            var customertype = _context.CurrencyTypes.SingleOrDefault(x => x.Id == existcustomer.CustomerTypeId);
            if (customertype != null) { existcustomer.CustomerTypeName = customertype.Name; }

            var delegateuser = _context.UserDelegates.SingleOrDefault(x => x.Id == existcustomer.UserDelegateId);
            if (delegateuser != null) { existcustomer.UserDelegateName = delegateuser.Name; }
            existcustomer.Name = existcustomer.FirstName + "" + existcustomer.MiddleName + "" + existcustomer.LastName;



            _context.Update(existcustomer);
            _context.SaveChanges();

            return true;
        }
    }
}
