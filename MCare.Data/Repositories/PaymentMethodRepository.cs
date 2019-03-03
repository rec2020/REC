using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {

        private NajmetAlraqeeContext _context;

        public PaymentMethodRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddPaymentMethod(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Add(paymentMethod);
            _context.SaveChanges();

            return paymentMethod.Id;
        }

        public PaymentMethod GetPaymentMethodById(int id)
        {
            return _context.PaymentMethods.Find(id);
        }

        public IQueryable<PaymentMethod> GetPaymentMethods()
        {
            return _context.PaymentMethods;
        }

        public bool RemovePaymentMethod(int id)
        {
            var paymentMethod = _context.PaymentMethods.SingleOrDefault(x => x.Id == id);
            if (paymentMethod == null)
                return false;

            _context.PaymentMethods.Remove(paymentMethod);
            _context.SaveChanges();
            return true;
        }

        public bool UpdatePaymentMethod(int id, PaymentMethod paymentMethod)
        {
            PaymentMethod existpaymentmethod = GetPaymentMethodById(id);
            if (existpaymentmethod == null)
                return false;
            existpaymentmethod.Name = paymentMethod.Name;
            existpaymentmethod.TreeAccountNo = paymentMethod.TreeAccountNo;
            _context.Update(existpaymentmethod);
            _context.SaveChanges();

            return true;
        }
    }
}
