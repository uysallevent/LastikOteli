using Lastikoteli.Models.MiyaPortal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class TakmaRequest
    {
        public SaklamaBilgiRequest saklamaBilgileri { get; set; }

        public Randevu isEmriBilgileri { get; set; }
    }
}
