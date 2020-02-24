using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class KullaniciUrunRequest
    {
        public int? LNGKOD { get; set; }
        public int? LNGLASTIKTIP { get; set; }
        public string TXTMARKA { get; set; }
        public string TXTTABAN { get; set; }
        public string TXTKESIT { get; set; }
        public string TXTCAP { get; set; }
        public string TXTMEVSIM { get; set; }
        public string TXTDESEN { get; set; }
        public int? BYTDURUM { get; set; }
        public int? LNGSONISLEMYAPANKULLANICI { get; set; }
    }
}
