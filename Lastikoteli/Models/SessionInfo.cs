using System;
namespace Lastikoteli.Models
{
    public class SessionInfo
    {
        public int lngKod { get; set; }
        public int lngPanKulKod { get; set; }
        public string txtAdSoyad { get; set; }
        public string txtDistAd { get; set; }
        public int lngDistkod { get; set; }
        public string txtAccessToken { get; set; }
        public DateTime trhExpiration { get; set; }
    }
}
