using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class KullaniciUrunResponse
    {
        public int lngKod { get; set; }
        public int lngLastikTip { get; set; }
        public string txtMarka { get; set; }
        public string txtTaban { get; set; }
        public string txtKesit { get; set; }
        public string txtCap { get; set; }
        public string txtMevsim { get; set; }
        public string txtDesen { get; set; }
    }
}
