using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class LastikEtiketRequest
    {
        public string txtPlaka { get; set; }
        public string txtMarka { get; set; }
        public string txtTaban { get; set; }
        public string txtKesit { get; set; }
        public string txtCap { get; set; }
        public string txtMevsim { get; set; }
        public string txtDesen { get; set; }
        public string txtYoneBilgisi { get; set; }
        public int lngSaklamaBaslik { get; set; }
        public string txtUnvan { get; set; }
        public string txtDistAdi { get; set; }
        public string txtKullaniciAdiSoyad { get; set; }
        public string txtAciklama { get; set; }
    }
}
