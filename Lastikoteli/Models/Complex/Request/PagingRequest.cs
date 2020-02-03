using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class PagingRequest
    {
        private int _sayfa;
        public int Sayfa
        {
            get
            {
                if (_sayfa == 0)
                    _sayfa = 1;
                return _sayfa;
            }
            set
            {
                _sayfa = value;
            }
        }
    }
}
