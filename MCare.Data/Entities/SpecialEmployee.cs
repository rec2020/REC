using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class SpecialEmployee
    {
        public int Id { get; set; }
        public string  Name  { get; set; }
        public string  PassportNo { get; set; }
        public int?  NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }
    }
}
