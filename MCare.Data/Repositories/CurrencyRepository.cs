using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {

        private NajmetAlraqeeContext _context;

        public CurrencyRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddCurrency(Currency currency)
        {
            var type = _context.CurrencyTypes.SingleOrDefault(x => x.Id == currency.CurrencyTypeId);
            if (type != null) { currency.CurrencyTypeName = type.Name; }

            _context.Currencies.Add(currency);
            _context.SaveChanges();

            return currency.Id;
        }

        public IQueryable<Currency> GetCurrencies()
        {
            return _context.Currencies;
        }

        public Currency GetCurrencyById(int id)
        {
            return _context.Currencies.Find(id);
        }

        public bool RemoveCurrency(int id)
        {
            var currency = _context.Currencies.SingleOrDefault(x => x.Id == id);
            if (currency == null)
                return false;

            _context.Currencies.Remove(currency);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCurrency(int id, Currency currency)
        {
            Currency existcurrency = GetCurrencyById(id);
            if (existcurrency == null)
                return false;
           


            existcurrency.Name = currency.Name;
            existcurrency.CurrencyTypeId = currency.CurrencyTypeId;

            var type = _context.CurrencyTypes.SingleOrDefault(x => x.Id == currency.CurrencyTypeId);
            if (type != null) { existcurrency.CurrencyTypeName = type.Name; }

            existcurrency.ExchangeRate = currency.ExchangeRate;
            existcurrency.Symbol = currency.Symbol;

            _context.Update(existcurrency);
            _context.SaveChanges();

            return true;
        }
    }
}
