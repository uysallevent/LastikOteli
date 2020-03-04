using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class SaklamaBaslikResponse
    {
        public int LNGKOD { get; set; }
        public int LNGDISTKOD { get; set; }
        public int LNGFILOKOD { get; set; }
        public DateTime TRHISLEMTARIHI { get; set; }
        public int LNGMUSTERIKOD { get; set; }
        public string TXTMUSTERIERPKOD { get; set; }
        public string TXTMUSTERIUNVAN { get; set; }
        public string TXTSOFORADSOYAD { get; set; }
        public string TXTPLAKA { get; set; }
        public int LNGARACKM { get; set; }
        public string TXTTCKIMLIKNO { get; set; }
        public string TXTVN { get; set; }
        public string TXTCEPTEL { get; set; }
        public string TXTEMAIL { get; set; }
        public string TXTACIKLAMA { get; set; }
        public string TXTTESLIMALANADSOYAD { get; set; }
        public int? LNGARACKOD { get; set; }
        public int? LNGFILOHIZMETFORMKOD { get; set; }
        public int? LNGHIZMETDISTKOD { get; set; }
        public int? LNGFATURADISTKOD { get; set; }
        public int? LNGPANFATURAKOD { get; set; }
        public int BYTFATURAKESILDI { get; set; }
        public int BYTETIKETBASIM { get; set; }
        public int BYTDURUM { get; set; }
        public int LNGSONISLEMYAPANKULLANICI { get; set; }
        public DateTime TRHSONISLEMTARIHI { get; set; }
        public List<SaklamaDetayResponse> Tblsaklamadetay { get; set; }
    }
}
