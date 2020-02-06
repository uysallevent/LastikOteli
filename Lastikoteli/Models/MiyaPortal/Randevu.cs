using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.MiyaPortal
{
    public class Randevu
    {
        public int LNGKOD { get; set; }
        public int? LNGSAKLAMABASLIK { get; set; }
        public int LNGDISTKOD { get; set; }
        public DateTime TRHISLEMTARIHI { get; set; }
        public int? LNGMUSTERIKOD { get; set; }
        public string TXTMUSTERIERPKOD { get; set; }
        public string TXTMUSTERIUNVAN { get; set; }
        public string TXTADSOYAD { get; set; }
        public string TXTPLAKA { get; set; }
        public string TXTTELEFON { get; set; }
        public string TXTEMAIL { get; set; }
        public Int64? LNGARACKM { get; set; }
        public int BYTSOKMETAKMA { get; set; }
        public int BYTSAKLAMA { get; set; }
        public string TXTACIKLAMA1 { get; set; }
        public string TXTACIKLAMA2 { get; set; }
        public string TXTACIKLAMA3 { get; set; }
        public string TXTACIKLAMA4 { get; set; }
        public string TXTACIKLAMA5 { get; set; }
        public DateTime? TRHHEDEFTARIH { get; set; }
        public int BYTRANDEVUDURUM { get; set; }
        public int BYTDURUM { get; set; }
        public int LNGSONISLEMYAPANKULLANICI { get; set; }
        public DateTime TRHSONISLEMTARIHI { get; set; }
    }
}
