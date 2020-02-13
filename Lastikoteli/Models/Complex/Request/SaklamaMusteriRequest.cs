using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class SaklamaMusteriRequest
    {
        public CustomViewMusteriBilgileriRequest Filter { get; set; }
        public PagingRequest Paging { get; set; }
    }
}
