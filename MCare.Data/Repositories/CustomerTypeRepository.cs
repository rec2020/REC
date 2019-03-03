using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
   public class CustomerTypeRepository : ICustomerTypeRepository
    {

        private NajmetAlraqeeContext _context;

        public CustomerTypeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddCustomerType(CustomerType customerType)
        {
            _context.CustomerTypes.Add(customerType);
            _context.SaveChanges();

            return customerType.Id;
        }

        public CustomerType GetCustomerTypeById(int id)
        {
            return _context.CustomerTypes.Find(id);
        }

        public IQueryable<CustomerType> GetCustomerTypes()
        {
            return _context.CustomerTypes;
        }

        public bool RemoveCustomerType(int id)
        {
            var customertype = _context.CustomerTypes.SingleOrDefault(x => x.Id == id);
            if (customertype == null)
                return false;

            _context.CustomerTypes.Remove(customertype);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCustomerType(int id, CustomerType customerType)
        {
            CustomerType existcustomertype = GetCustomerTypeById(id);
            if (existcustomertype == null)
                return false;
            existcustomertype.Name = customerType.Name;
            _context.Update(existcustomertype);
            _context.SaveChanges();

            return true;
        }
    }
}
