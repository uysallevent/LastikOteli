using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class AracUzerindekilerResponse
    {
        public int lngLastikTip { get; set; }
        public string txtUrunKod { get; set; }
        public string txtMarka { get; set; }
        public string txtTaban { get; set; }
        public string txtKesit { get; set; }
        public string txtCap { get; set; }
        public string txtMevsim { get; set; }
        public string txtDesen { get; set; }
        public List<MarkaBilgiResponse> markaList { get; set; }
        public List<MarkaBilgiResponse> tabanList { get; set; }
        public List<MarkaBilgiResponse> kesitList { get; set; }
        public List<MarkaBilgiResponse> capList { get; set; }
        public List<MarkaBilgiResponse> mevsimList { get; set; }
        public List<MarkaBilgiResponse> desenList { get; set; }
    }
}
