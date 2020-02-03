using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class TerminalKullaniciFilterRequest
    {
        public int lngDistKod { get; set; }
        public string txtAd { get; set; }
        public string txtSoyad { get; set; }
        public string txtKullaniciAd { get; set; }
        public string txtSifre { get; set; }
        public int? lngDepoSayi { get; set; }
    }
}
