using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
   public  class LastikSaklamaBilgiResponse
    {
        public int lngSaklamaKodu { get; set; }
        public string txtPlaka { get; set; }
        public string txtDurum { get; set; }
    }
}
