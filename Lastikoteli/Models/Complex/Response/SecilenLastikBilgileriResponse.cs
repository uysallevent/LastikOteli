using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class SecilenLastikBilgileriResponse
    {
        public int? markaIndex { get; set; }
        public int? tabanIndex { get; set; }
        public int? kesitIndex { get; set; }
        public int? capIndex { get; set; }
        public int? mevsimIndex { get; set; }
        public int? desenIndex { get; set; }
        public string[] markaListe { get; set; }
        public string[] tabanListe { get; set; }
        public string[] kesitListe { get; set; }
        public string[] capListe { get; set; }
        public string[] mevsimListe { get; set; }
        public string[] desenListe { get; set; }
        public string txtUrunKod { get; set; }
    }
}
