using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class TerminalKullaniciListeRequest
    {
        public TerminalKullaniciFilterRequest filter { get; set; }
        public PagingRequest Paging { get; set; }
    }
}
