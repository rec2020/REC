using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class AccountClassification
    {
        public int Id { get; set; }
        public string  DescriptionAr { get; set; }
        public string  DescriptionEn { get; set; }
        public int?  TypeId { get; set; }
        public virtual AccountClassificationType Type { get; set; }
    }
}
