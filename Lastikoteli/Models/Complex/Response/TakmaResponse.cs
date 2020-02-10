using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class TakmaResponse
    {
        public int lngSaklamaKod { get; set; }
        public string txtPozisyon { get; set; }
        public string txtLastik { get; set; }
        public string txtRaf { get; set; }
        public int lngOTL { get; set; }
        private bool _bytOTL;
        public bool bytOTL
        {
            get { return _bytOTL; }
            set { _bytOTL = value; }
        }

    }
}
