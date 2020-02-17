using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class DepoDizilimResponse
    {
        public int lngKod { get; set; }
        public int lngDistKod { get; set; }
        public string txtAd { get; set; }
        public string txtKod { get; set; }
        public string txtAciklama { get; set; }
        public int lngKapasite { get; set; }
    }
}
