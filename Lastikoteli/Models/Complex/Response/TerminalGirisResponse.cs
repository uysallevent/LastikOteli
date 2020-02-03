using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class TerminalGirisResponse
    {
        public int lngKod { get; set; }
        public int lngPanKulKod { get; set; }
        public string txtAdSoyad { get; set; }
        public string txtDistAd { get; set; }
        public int lngDistkod { get; set; }
    }
}
