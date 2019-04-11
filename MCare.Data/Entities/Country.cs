using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class Country
    {    
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }
    }
}
