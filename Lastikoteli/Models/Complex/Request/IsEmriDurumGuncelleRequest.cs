using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class IsEmriDurumGuncelleRequest
    {
        public int lngDistKod { get; set; }
        /// <summary>
        /// lngIsEmriKod
        /// </summary>
        public int lngKod { get; set; }
        /// <summary>
        /// 1-Takma iş emri
        /// 2-Saklama iş emri
        /// 3-Takma/Saklama iş emri
        /// </summary>
        public int lngTip { get; set; }
        /// <summary>
        /// bytDurum 1 olan iş emirlerinin 2'ye el terminali üzerinden çevrilmesi 
        /// iş emrinin kapatıldığını belirtir. El terminalinde iş emri listesinde gösterilmez
        /// </summary>
        public int bytDurum { get; set; }
    }
}
