using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.Helper
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

        public enum ReceiptdocType {
            SnadReceive = 1,
            SnadTaking
        }

        public enum ContractType
        {
            New = 1,
            Substitute,
            Specific
           
        }
       
    }
}
