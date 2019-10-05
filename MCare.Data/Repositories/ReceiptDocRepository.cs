using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class ReceiptDocRepository : IReceiptDocRepository
    {

        private NajmetAlraqeeContext _context;

        public ReceiptDocRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int RecruitmentQaidTaking(ReceiptDoc receipt)
        {
             #region AddQaid 
            // Add RecruitmentQaid First 
            RecruitmentQaid qaid = new RecruitmentQaid
            {
                QaidDate = DateTime.UtcNow.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                StatusId = (int)EnumHelper.RecruitmentQaidStatus.Open
            };
            var getCurrentFinancialPeriod = _context.FinancialPeriods.Where(x => x.FinancialPeriodStatusId == (int)EnumHelper.FinancPeriodStatus.CURRENT).SingleOrDefault();
            if (getCurrentFinancialPeriod != null)
            {
                qaid.FinancialPeriodId = getCurrentFinancialPeriod.Id;
            }
            if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking)
            {
                qaid.TypeId = (int)EnumHelper.RecruitmentQaidTypes.Take;
            }
            _context.RecruitmentQaids.Add(qaid);
            _context.SaveChanges();
            #endregion

            #region DEBIT

            
            var paymentMethod = _context.PaymentMethods.Where(x => x.Id == receipt.PaymentMethodId).SingleOrDefault();
            if (paymentMethod != null)
            {
                // Add RecruitmentQaidDetails  ------DEBIT
                RecruitmentQaidDetail detailDebit = new RecruitmentQaidDetail {
                QaidId = qaid.Id,
                Debit = receipt.Amount,
                TypeId = (int)EnumHelper.RecruitmentQaidDetailType.Debit,
                AccountTreeId = paymentMethod.AccountTreeId ,
                Note=""
            };
            _context.RecruitmentQaidDetails.Add(detailDebit);
            _context.SaveChanges();
            // change In AccountTree For Debit Account 
            AccountTree existAcc = _context.AccountTrees.Where(x => x.Id == detailDebit.AccountTreeId).SingleOrDefault();
            if (existAcc != null)
            {
               existAcc.Debit = existAcc.Debit + detailDebit.Debit;
                _context.Update(existAcc);
                _context.SaveChanges();
            }
               
           }
            #endregion

            #region CREDIT

            var customer = _context.Customers.Where(x => x.Id == receipt.CustomerId).SingleOrDefault();
            if (customer != null)
            {
                // Add RecruitmentQaidDetails   ------Credit 
                RecruitmentQaidDetail detailCredit = new RecruitmentQaidDetail
                {
                    QaidId = qaid.Id,
                    Credit = receipt.Amount,
                    TypeId = (int)EnumHelper.RecruitmentQaidDetailType.Credit,
                    AccountTreeId = customer.AccountTreeId,
                    Note = ""
                };
                _context.RecruitmentQaidDetails.Add(detailCredit);
                _context.SaveChanges();
                // change In AccountTree For Credit Account 
                AccountTree existAccCredit = _context.AccountTrees.Where(x => x.Id == detailCredit.AccountTreeId).SingleOrDefault();
                if (existAccCredit != null)
                {
                    existAccCredit.Credit = existAccCredit.Credit + detailCredit.Credit;
                    _context.Update(existAccCredit);
                    _context.SaveChanges();
                }
               
            }

            #endregion

            return qaid.Id;
        }

        public int RecruitmentQaidSnadReceive(ReceiptDoc receipt)
        {
            #region AddQaid 
            // Add RecruitmentQaid First 
            RecruitmentQaid qaid = new RecruitmentQaid
            {
                QaidDate = DateTime.UtcNow.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                StatusId = (int)EnumHelper.RecruitmentQaidStatus.Open
            };
            var getCurrentFinancialPeriod = _context.FinancialPeriods.Where(x => x.FinancialPeriodStatusId == (int)EnumHelper.FinancPeriodStatus.CURRENT).SingleOrDefault();
            if (getCurrentFinancialPeriod != null)
            {
                qaid.FinancialPeriodId = getCurrentFinancialPeriod.Id;
            }
            if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive)
            {
                qaid.TypeId = (int)EnumHelper.RecruitmentQaidTypes.Exchange;
            }
            
            _context.RecruitmentQaids.Add(qaid);
            _context.SaveChanges();
            #endregion

            #region DEBIT


            var customerReciepe = _context.Customers.Where(x => x.Id == receipt.CustomerId).SingleOrDefault();
            if (customerReciepe != null)
            {
                // Add RecruitmentQaidDetails  ------DEBIT
                RecruitmentQaidDetail detailDebit = new RecruitmentQaidDetail
                {
                    QaidId = qaid.Id,
                    Debit = receipt.Amount,
                    TypeId = (int)EnumHelper.RecruitmentQaidDetailType.Debit,
                    AccountTreeId = customerReciepe.AccountTreeId,
                    Note = ""
                };
                _context.RecruitmentQaidDetails.Add(detailDebit);
                _context.SaveChanges();
                // change In AccountTree For Debit Account 
                AccountTree existAcc = _context.AccountTrees.Where(x => x.Id == detailDebit.AccountTreeId).SingleOrDefault();
                if (existAcc != null)
                {
                    existAcc.Debit = existAcc.Debit + detailDebit.Debit;
                    _context.Update(existAcc);
                    _context.SaveChanges();
                }

            }
            #endregion

            #region CREDIT

            var paymentmethodreciepe = _context.PaymentMethods.Where(x => x.Id == receipt.PaymentMethodId).SingleOrDefault();
            if (paymentmethodreciepe != null)
            {
                // Add RecruitmentQaidDetails   ------Credit 
                RecruitmentQaidDetail detailCredit = new RecruitmentQaidDetail
                {
                    QaidId = qaid.Id,
                    Credit = receipt.Amount,
                    TypeId = (int)EnumHelper.RecruitmentQaidDetailType.Credit,
                    AccountTreeId = paymentmethodreciepe.AccountTreeId,
                    Note = ""
                };
                _context.RecruitmentQaidDetails.Add(detailCredit);
                _context.SaveChanges();
                // change In AccountTree For Credit Account 
                AccountTree existAccCredit = _context.AccountTrees.Where(x => x.Id == detailCredit.AccountTreeId).SingleOrDefault();
                if (existAccCredit != null)
                {
                    existAccCredit.Credit = existAccCredit.Credit + detailCredit.Credit;
                    _context.Update(existAccCredit);
                    _context.SaveChanges();
                }

            }

            #endregion

            return qaid.Id;
        }

        public int AddReceiptDoc(ReceiptDoc receipt)
        {
            var qaidId = 0;
            // Add RecruitmentQaid First 
            if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking)
            {
                 qaidId = RecruitmentQaidTaking(receipt);
            }
            else {
                qaidId = RecruitmentQaidSnadReceive(receipt);
            }
            //  Add ReceiptDoc 
            var getCurrentFinancialPeriodrec = _context.FinancialPeriods.Where(x => x.FinancialPeriodStatusId == (int)EnumHelper.FinancPeriodStatus.CURRENT).SingleOrDefault();
            if (getCurrentFinancialPeriodrec != null)
            {
                receipt.FinancialPeriodId = getCurrentFinancialPeriodrec.Id;
            }
            receipt.QaidNo = qaidId;
            _context.ReceiptDocs.Add(receipt);
            _context.SaveChanges();

            // update Contract
            if (receipt.ContractTypeId == (int)EnumHelper.ContractType.New || receipt.ContractTypeId == (int)EnumHelper.ContractType.Substitute)
            {
                if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive)
                {
                    var cont = _context.Contracts.Find(receipt.ContractId);
                    if (cont != null)
                    {
                        cont.Recieved = cont.Recieved + receipt.Amount;
                       
                        _context.Update(cont);
                        _context.SaveChanges();
                    }
                }
                if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking)
                {
                    var cont = _context.Contracts.Find(receipt.ContractId);
                    if (cont != null)
                    {
                        cont.Paid = cont.Paid + receipt.Amount;
                        cont.Remainder = cont.Remainder - receipt.Amount;
                        _context.Update(cont);
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive)
                {
                    var cont = _context.SpecificContracts.Find(receipt.ContractId);
                    if (cont != null)
                    {
                        cont.Remainder = cont.Remainder - receipt.Amount;
                        _context.Update(cont);
                        _context.SaveChanges();
                    }
                }
                if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking)
                {
                    var cont = _context.SpecificContracts.Find(receipt.ContractId);
                    if (cont != null)
                    {
                        cont.Paid = cont.Paid + receipt.Amount;
                        _context.Update(cont);
                        _context.SaveChanges();
                    }
                }
            }
            return receipt.Id;
        }

        public ReceiptDoc GetReceiptDocById(int Id)
        {
            return _context.ReceiptDocs.Include(x => x.ReceiptdocType).Include(x => x.Customer).Include(x=>x.PaymentMethod)
            .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ReceiptDoc> GetReceiptDocs()
        {
            return _context.ReceiptDocs.Include(x => x.ReceiptdocType).Include(x => x.Customer).Include(x => x.PaymentMethod);
        }

        public bool RemoveReceiptDoc(int Id)
        {
            ReceiptDoc receipt = GetReceiptDocById(Id);
            if (receipt == null)
                return false;

            _context.Remove(receipt);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateReceiptDoc(int Id, ReceiptDoc rec)
        {
            ReceiptDoc existreceipt = GetReceiptDocById(Id);
            if (existreceipt == null)
                return false;
            existreceipt.ReceiptDate = rec.ReceiptDate;
            existreceipt.ReceiptByUser = rec.ReceiptByUser;
            existreceipt.VAT = rec.VAT;
            existreceipt.ContractId = rec.ContractId;
            existreceipt.Amount = rec.Amount;
            existreceipt.PaymentMethodId = rec.PaymentMethodId;
            existreceipt.CustomerId = rec.CustomerId;
            _context.Update(existreceipt);
            _context.SaveChanges();

            return true;
        }
    }
}
