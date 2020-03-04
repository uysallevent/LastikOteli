using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class SaklamaDetayResponse
    {
        public int LNGKOD { get; set; }
        public int LNGSAKLAMABASLIKKOD { get; set; }
        public int LNGURUNTIP { get; set; }
        public int LNGKULLANICIURUNKOD { get; set; }
        public string TXTURUNKOD { get; set; }
        public int LNGLASTIKTIP { get; set; }
        public int? LNGDEPOSIRAKOD { get; set; }
        public string TXTDOTURETIM { get; set; }
        public string TXTDOTFABRIKA { get; set; }
        public string TXTDOTHAFTA { get; set; }
        public decimal? DBLDISDERINLIGI { get; set; }
        public string TXTACIKLAMA { get; set; }
        public string TXTTESLIMACIKLAMA { get; set; }
        public string TXTTESLIMALAN { get; set; }
        public int LNGLASTIKDURUM { get; set; }
        public int? BYTHAVUZDA { get; set; }
        public int BYTOTL { get; set; }
        public int BYTDURUM { get; set; }
        public int LNGSONISLEMYAPANKULLANICI { get; set; }
        public DateTime TRHSONISLEMTARIHI { get; set; }
    }
}
