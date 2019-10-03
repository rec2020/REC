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
        public decimal CommissionValue { get; set; }
        public decimal CommissionPrecentage { get; set; }

        public decimal DeservedAmount { get; set; }
        public decimal RemainderAmount { get; set; }

        public decimal TransferAmount { get; set; }


        public int? AccountTreeId { get; set; }

        public virtual AccountTree AccountTree { get; set; }
        public virtual Nationality Nationality  { get; set; }
        public virtual DelegateType DelegateType { get; set; }
        //public virtual Customer Customer { get; set; }
    }
}
