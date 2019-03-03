using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IPaymentMethodRepository
    {

        IQueryable<PaymentMethod> GetPaymentMethods();
        PaymentMethod GetPaymentMethodById(int id);
        int AddPaymentMethod(PaymentMethod paymentMethod);
        bool UpdatePaymentMethod(int id, PaymentMethod paymentMethod);
        bool RemovePaymentMethod(int id);
    }
}
