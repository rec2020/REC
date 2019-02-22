using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Site.Models.Lookups
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
