using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Data.Constants
{
    public class EnumHelper
    {
        public enum EmployeeStatus
        {
            UnderWork = 1,
            UnderTest,
            FinalExit,
            Escape,
            IqamaTransfer,
            InHousing,
            New
        }

        public enum ContractStatus
        {
            New = 1,
            Select,
            Delegate,
            Visa,
            Ticket,
            Return,
            Close,
            UnderTest
        }
        public enum ContractAction
        {
            New = 1,
            Select,
            Delegate,
            Visa,
            Ticket,
            Return,
            Close
        }
        public enum ReceiptdocType
        {
            SnadReceive = 1,
            SnadTaking
        }
        public enum ContractType
        {
            New = 1,
            Substitute,
            Specific

        }
        public enum FinancPeriodStatus
        {
            CURRENT = 1,
            OPEN,
            CLOSE
        }

        public enum RecruitmentQaidStatus
        {
            Open=1,
            Close
        }

        public enum RecruitmentQaidTypes
        {
             Exchange= 1,
            Take,
            Transfer
        }

        public enum RecruitmentQaidDetailType
        {
            Credit = 1,
            Debit
        }
    }
}
