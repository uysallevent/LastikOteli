using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class IsEmriResponse
    {
        public int lngKod { get; set; }
        public int lngDistKod { get; set; }
        public int? lngMusteriKod { get; set; }
        public string txtMusteriErpKod { get; set; }
        public string txtMusteriUnvan { get; set; }
        public string txtAdSoyad { get; set; }
        public string txtPlaka { get; set; }
        public string txtTelefon { get; set; }
        public string txtEmail { get; set; }
        public int? lngAracKm { get; set; }
        public int bytSokmeTakma { get; set; }
        public int bytSaklama { get; set; }
        public string txtAciklama1 { get; set; }
        public string txtAciklama2 { get; set; }
        public string txtAciklama3 { get; set; }
        public string txtAciklama4 { get; set; }
        public string txtAciklama5 { get; set; }
        public DateTime? trhHedefTarih { get; set; }
        public int bytRandevuDurum { get; set; }
    }
}
