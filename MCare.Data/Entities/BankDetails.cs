using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
  public class BankDetail
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public int? AccountTreeId { get; set; }
        public virtual AccountTree AccountTree  { get; set; }

    }
}
