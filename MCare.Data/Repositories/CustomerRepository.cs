using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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
            // Add Customer Account In the Tree 
            var getLastCustomerAccount = _context.AccountTrees.Where(x => x.Accprev.Contains("01002006000")).LastOrDefault();
            var getCustomerAccount = _context.AccountTrees.Where(x => x.AccountNo.Contains("01002006000")).SingleOrDefault();
            if (getCustomerAccount !=null) { 
            AccountTree Acc = new AccountTree
            {
                DescriptionAr = customer.FirstName + "    " + customer.LastName,
                DescriptionEn = customer.FirstName + "    " + customer.LastName,
                AccountLevel = getCustomerAccount.AccountLevel + 1 , 
                AccClassificationId = getCustomerAccount.AccClassificationId,
                AccTypeId = getCustomerAccount.AccTypeId , 
                Accprev = getCustomerAccount.AccountNo,
                CostCenter = getCustomerAccount.CostCenter,
                ParentId = getCustomerAccount.Id,
                EhalkPrecent = 0,
                HighLimitForBalance = 0,
                PriceInExhibtion=0,
                JE = null,
                Debit = 0,
                Credit = 0,
                Balance = 0,
            };
                if (getLastCustomerAccount != null)
                {
                    var newacouuntnumber = int.Parse(getLastCustomerAccount.AccountNo);
                    newacouuntnumber += 1;
                    Acc.AccountNo = "0" + newacouuntnumber.ToString();
                }
                else
                {
                    var newacouuntnumber = int.Parse(getCustomerAccount.AccountNo);
                    newacouuntnumber += 1;
                    Acc.AccountNo = "0" + newacouuntnumber.ToString();
                }

                _context.AccountTrees.Add(Acc);
            _context.SaveChanges();
            customer.AccountTreeId = Acc.Id;
            }
            // 
            customer.Name = customer.FirstName + "  " + customer.LastName;
           
            customer.IsActive = true;
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer.Id;
        }

        public Customer GetCustomerById(int Id)
        {
            return _context.Customers.Include(x => x.CustomerType)
                .Include(x => x.UserDelegate)
                .Include(x => x.AccountTree)
                .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers.Include(x=>x.CustomerType).Include(x => x.AccountTree).Include(x=>x.UserDelegate);
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
            existcustomer.SecondPhone = customer.IdentiyImage;
            existcustomer.FirstPhone = customer.IdentityNo;
            existcustomer.CustomerTypeId = customer.CustomerTypeId;
            existcustomer.UserDelegateId = customer.UserDelegateId;
            existcustomer.Name = customer.FirstName + "  " + customer.LastName;

            _context.Update(existcustomer);
            _context.SaveChanges();

            return true;
        }

        public bool ActivationCustomer(int Id, Customer cust)
        {
            Customer existcustomer = GetCustomerById(Id);
            if (existcustomer == null)
                return false;
            existcustomer.IsActive = cust.IsActive;
            _context.Update(existcustomer);
            _context.SaveChanges();

            return true;
        }
    }
}
