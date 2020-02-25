using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class SecilenLastikResponse
    {
        public int lngLastikYon { get; set; }

        public List<MarkaBilgiResponse> markaListe { get; set; }
        public List<MarkaBilgiResponse> tabanListe { get; set; }
        public List<MarkaBilgiResponse> kesitListe { get; set; }
        public List<MarkaBilgiResponse> capListe { get; set; }
        public List<MarkaBilgiResponse> mevsimListe { get; set; }
        public List<MarkaBilgiResponse> desenListe { get; set; }
    }
}
