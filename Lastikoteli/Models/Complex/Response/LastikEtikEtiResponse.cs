using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class LastikEtikEtiResponse
    {
        public int lngSaklamaKod { get; set; }

        private string _lastikYonBilgisi;
        public string lastikYonBilgisi
        {
            get { return _lastikYonBilgisi; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value == "onSag")
                        _lastikYonBilgisi = "Ön Sağ";
                    if (value == "onSol")
                        _lastikYonBilgisi = "Ön Sol";
                    if (value == "arkaSag")
                        _lastikYonBilgisi = "Arka Sağ";
                    if (value == "arkaSol")
                        _lastikYonBilgisi = "Arka Sol";
                    if (value == "diigerSag")
                        _lastikYonBilgisi = "Diğer Sağ";
                    if (value == "dgerSol")
                        _lastikYonBilgisi = "Diğer Sol";
                }

            }
        }

        public int lngLastikAdet { get; set; }
    }
}
