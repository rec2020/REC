using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class SingleItemResponseModel<T> where T : class
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Item { get; set; }

        public SingleItemResponseModel(string message, T item)
        {
            Status = true;
            Message = message;
            Item = item ;
        }

        public SingleItemResponseModel(T item)
        {
            Status = true;
            Message = string.Empty;
            Item = item;
        }
    }
}
