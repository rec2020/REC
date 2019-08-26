using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class AccountTree
    {
        public int Id {get; set;}
        public string AccountNo { get; set;}
        public string DescriptionAr { get; set;}
        public string  DescriptionEn { get; set;}
        public int? AccountLevel { get; set; }
        public int? AccClassificationId { get; set; }
        public int?  AccTypeId { get; set; }
        public string  Accprev { get; set; }
        public decimal?  Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Balance { get; set; }
        public int? ParentId { get; set; }
        public decimal? PriceInExhibtion { get; set; }
        public decimal? HighLimitForBalance { get; set; }
        public int? EhalkPrecent { get; set; }
        public string FixedAssetDate { get; set; }
        public string JE { get; set; }
        public string CostCenter { get; set; }



        public virtual AccountClassificationType AccType { get; set; }
        public virtual AccountTree Parent { get; set; }
        public virtual  AccountClassification AccClassification  { get; set; }
    }
}
