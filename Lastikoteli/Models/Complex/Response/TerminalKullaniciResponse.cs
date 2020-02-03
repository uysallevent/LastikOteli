using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class TerminalKullaniciResponse
    {
        public int lngKod { get; set; }
        public int lngDistKod { get; set; }
        public int lngPanoramaKullaniciKod { get; set; }
        public string txtAd { get; set; }
        public string txtSoyad { get; set; }
        public string txtKullaniciAd { get; set; }
        public int lngDepoSayi { get; set; }
        public List<KeyValuePair<string, int>> depoListe { get; set; }
    }
}
