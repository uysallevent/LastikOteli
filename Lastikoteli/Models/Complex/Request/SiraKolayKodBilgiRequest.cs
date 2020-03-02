using Lastikoteli.Models.Complex.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class SiraKolayKodBilgiRequest
    {
        public string desenKodu { get; set; }
        public List<DepoDizilimResponse> rafKolayKodListesi { get; set; }
    }
}
