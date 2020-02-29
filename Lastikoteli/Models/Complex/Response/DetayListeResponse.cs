using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class DetayListeResponse
    {
        public int lngKod { get; set; }
        public int lngUrunTip { get; set; }
        public string txtUrunKod { get; set; }
        public int lngLastikTip { get; set; }
        public int? lngDepoSiraKod { get; set; }
        public string txtLastikDurum { get; set; }
        public string txtRafKolayKod { get; set; }
        public string txtLastikYon { get; set; }
        public string txtDotUretim { get; set; }
        public string txtDotFabrika { get; set; }
        public string txtDotHafta { get; set; }
        public decimal? dblDisDerinligi { get; set; }
        public string txtAciklama { get; set; }
        public string txtMarka { get; set; }
        public string txtTaban { get; set; }
        public string txtKesit { get; set; }
        public string txtCap { get; set; }
        public string txtMevsim { get; set; }
        public string txtDesen { get; set; }
        public int bytDurum { get; set; }
        public int bytHavuzda { get; set; }
        public KullaniciUrunResponse kullaniciUrunResponse { get; set; }
        public List<KeyValuePair<string, bool>> markaListe { get; set; }
        public List<KeyValuePair<string, bool>> tabanListe { get; set; }
        public List<KeyValuePair<string, bool>> kesitListe { get; set; }
        public List<KeyValuePair<string, bool>> capListe { get; set; }
        public List<KeyValuePair<string, bool>> mevsimListe { get; set; }
        public List<KeyValuePair<string, bool>> desenListe { get; set; }
    }
}
