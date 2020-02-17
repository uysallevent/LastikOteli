using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class DepoDizilimRequest
    {
        public int lngDistKod { get; set; }
        public int lngDepoSira { get; set; }
        public int? lngKod { get; set; }
    }
}
