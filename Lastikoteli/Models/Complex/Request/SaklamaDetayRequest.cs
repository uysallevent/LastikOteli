using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class SaklamaDetayRequest
    {
        public int? LNGKOD { get; set; }
        public int? LNGSAKLAMABASLIKKOD { get; set; }
        /// <summary>
        /// 1-Brisa Ürünü
        /// 2-Diğer Ürün
        /// </summary>
        public int? LNGURUNTIP { get; set; }
        public int? LNGKULLANICIURUNKOD { get; set; }
        public string TXTURUNKOD { get; set; }
        public int? LNGLASTIKTIP { get; set; }
        public int? LNGDEPOSIRAKOD { get; set; }
        public string TXTDOTURETIM { get; set; }
        public string TXTDOTFABRIKA { get; set; }
        public string TXTDOTHAFTA { get; set; }
        public decimal? DBLDISDERINLIGI { get; set; }
        public string TXTACIKLAMA { get; set; }
        public int BYTHAVUZDA { get; set; }
        public int? LNGLASTIKDURUM { get; set; }
        public int ISOTL { get; set; }
        public int BYTDURUM { get; set; }
        public int LNGSONISLEMYAPANKULLANICI { get; set; }
        public KullaniciUrunRequest kullaniciUrunBilgileri { get; set; }

    }
}
