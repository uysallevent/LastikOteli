using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class IsEmriGetirRequest
    {
        public string txtPlaka { get; set; }
        public int lngDistKod { get; set; }
        public int lngKod { get; set; }
    }
}
