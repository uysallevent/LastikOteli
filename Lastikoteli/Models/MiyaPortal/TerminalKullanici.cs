using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.MiyaPortal
{
    public class TerminalKullanici
    {
        public int LNGKOD { get; set; }
        public int LNGDISTKOD { get; set; }
        public int LNGPANKULLANICIKOD { get; set; }
        public string TXTAD { get; set; }
        public string TXTSOYAD { get; set; }
        public string TXTKULLANICIAD { get; set; }
        public string TXTSIFRE { get; set; }
        public int BYTDURUM { get; set; }
        public int LNGSONISLEMYAPANKULLANICI { get; set; }
        public DateTime TRHSONISLEMTARIHI { get; set; }
        public List<KeyValuePair<string,int>> TERMINALKULLANICIDEPOLIST { get; set; }
    }
}
