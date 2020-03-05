using LinkOS.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class PrintRequest
    {
        //public LastikEtiketBilgileriRequest lastikEtiketBilgileri { get; set; }
        public List<KeyValuePair<string,string>> lastikEtiketlerBilgi { get; set; }
        public SiraKolayKodBilgiRequest siraKolayKodEtiketBilgileri { get; set; }
    }
}
