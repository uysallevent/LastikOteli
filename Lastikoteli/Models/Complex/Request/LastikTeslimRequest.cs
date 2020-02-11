using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class LastikTeslimRequest
    {
        public int lngDistKod { get; set; }
        public int lngSaklamaBaslik { get; set; }
        public string txtKullaniciAdSoyad { get; set; }
        public string txtAciklama { get; set; }
    }
}
