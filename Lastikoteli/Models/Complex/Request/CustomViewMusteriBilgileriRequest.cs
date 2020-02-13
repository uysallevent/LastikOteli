using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class CustomViewMusteriBilgileriRequest
    {
        public int LNGDISTKOD { get; set; }
        public int LNGKOD { get; set; }
        public string TXTERPKOD { get; set; }
        public string TXTUNVAN { get; set; }
    }
}
