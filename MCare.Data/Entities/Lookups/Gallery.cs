using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities.Lookups
{
    public class Gallery
    {
        public long Id { get; set; }
        public long HospitalId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string ImagePath { get; set; }

        public virtual Hospital Hospital { get; set; }
    }
}
