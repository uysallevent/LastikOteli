using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class IsEmriRequest
    {
        public int lngDistKod { get; set; }
        public DateTime trhBasTarih { get; set; }
        public DateTime trhBitTarih { get; set; }
        public string txtMusteriErpKod { get; set; }
        public string txtMusteriUnvan { get; set; }
        public string txtAdSoyad { get; set; }
        public string txtPlaka { get; set; }
        public string txtTelefon { get; set; }
        public string txtEmail { get; set; }
        public string txtRandevuDurum { get; set; }
        public DateTime? trhHedefTarih { get; set; }
    }
}
