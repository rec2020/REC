using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class MultiItemsResponseModel<T> where T : class
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public PagingModel Paging { get; set; }
        public IEnumerable<T> Items { get; set; }

        public MultiItemsResponseModel(string message, IEnumerable<T> items)
        {
            Status = true;
            Message = message;
            Items = items;
        }

        public MultiItemsResponseModel(IEnumerable<T> items,
            int totalPages, int currentPage,
            int totalItems, int itemPerPage)
        {
            Status = true;
            Message = string.Empty;
            Items = items;

            Paging = new PagingModel()
            {
                CurrentPage = currentPage,
                ItemPerPage = itemPerPage,
                TotalItems = totalItems,
                TotalPages = totalPages
            };
        }
    }

    public class PagingModel
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int ItemPerPage { get; set; }
    }
}
