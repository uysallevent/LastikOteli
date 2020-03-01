using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class LastikRafGuncelleRequest
    {
        public int lngDistKod { get; set; }
        public int lngSaklamaKodu { get; set; }
        public List<KeyValuePair<int, int>> detayKodRafKodList { get; set; }
    }
}
