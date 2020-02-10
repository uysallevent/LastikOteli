using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class SaklamaBilgileriResponse
    {
        public int lngKod { get; set; }
        public string txtMusteriErpKod { get; set; }
        public string txtMusteriUnvan { get; set; }
        public string txtSoforAdSoyad { get; set; }
        public string txtPlaka { get; set; }
        public int lngAracKm { get; set; }
        public string txtTcKimlikNo { get; set; }
        public string txtVn { get; set; }
        public string txtCepTel { get; set; }
        public string txtEmail { get; set; }
        public string txtAciklama { get; set; }

        public List<DetayListeResponse> Tblsaklamadetay { get; set; }
    }
}
