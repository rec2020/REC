using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class UserDelegate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال جنسية المندوب")]
        public int NationalityId { get; set; }
        public int DelegateTypeId { get; set; }
        //public string DelegateTypeName { get; set; }
        public Decimal CommissionValue { get; set; }
        public Decimal CommissionPrecentage { get; set; }

        public string AccountNoTree { get; set; }

        public Decimal DeservedAmount { get; set; }
        public Decimal RemainderAmount { get; set; }

        public Decimal TransferAmount { get; set; }

        public virtual Nationality Nationality  { get; set; }
        public virtual DelegateType DelegateType { get; set; }
        //public virtual Customer Customer { get; set; }
    }
}
