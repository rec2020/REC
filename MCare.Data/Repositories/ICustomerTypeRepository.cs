using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
     public  interface ICustomerTypeRepository
    {

        IQueryable<CustomerType> GetCustomerTypes();
        CustomerType GetCustomerTypeById(int id);
        int AddCustomerType(CustomerType customerType);
        bool UpdateCustomerType(int id, CustomerType customerType);
        bool RemoveCustomerType(int id);
    }
}
