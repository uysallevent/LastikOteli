using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class IsEmriListeRequest
    {
        public IsEmriRequest Filter { get; set; }
        public PagingRequest Paging { get; set; }
    }
}
