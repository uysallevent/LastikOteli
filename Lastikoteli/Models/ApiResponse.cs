using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models
{
    public class ApiResponse
    {
        public string Version { get; set; }
        public int StatusCode { get; set; }
        public string RequestId { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }
    }
}
