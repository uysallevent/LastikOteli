using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class LastikEtiketBilgileriRequest
    {
        public string desenKodu { get; set; }
        public List<LastikEtiketRequest> lastikListesi { get; set; }
    }
}
