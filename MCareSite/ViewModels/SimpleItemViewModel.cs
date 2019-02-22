using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class SimpleItemViewModel
    {
        public string Field { get; set; }
        public string Value { get; set; }

        public SimpleItemViewModel(string field, string name)
        {
            Field = field;
            Value = name;
        }
    }
}
