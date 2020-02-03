using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models
{
    public class ApiResponseGeneric<T>
    {
        public string Version { get; set; }
        public int StatusCode { get; set; }
        public string RequestId { get; set; }
        public string ErrorMessage { get; set; }

        private T _result;

        public T Result
        {
            get { return _result; }
            set { _result = value; }
        }

    }
}
