using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class SaklamaBilgiRequest
    {
        public int lngDistKod { get; set; }
        public int? lngSaklamaBaslik { get; set; }
        public string txtPlaka { get; set; }
    }
}
