using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class City
    {       
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
       
        public virtual Country Country { get; set; }
        //public virtual Contract Contract { get; set; }
        //public virtual ContractTicket ContractTicket { get; set; }
    }
}
