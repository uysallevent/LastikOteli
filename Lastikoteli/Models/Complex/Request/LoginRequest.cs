using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class LoginRequest
    {
        public string kullaniciAd { get; set; }
        public string sifre { get; set; }
    }
}
