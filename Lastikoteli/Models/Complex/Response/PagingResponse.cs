using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms.Extended;

namespace Lastikoteli.Models.Complex.Response
{
    public class PagingResponse<T>
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public InfiniteScrollCollection<T> Data { get; set; }
    }
}
