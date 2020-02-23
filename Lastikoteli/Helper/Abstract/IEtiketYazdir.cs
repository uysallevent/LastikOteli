using Lastikoteli.Models.Complex.Request;
using LinkOS.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Helper.Abstract
{
    public interface IEtiketYazdir
    {
        void SendZplReceipt(IConnection printerConnection, PrintRequest request);
    }
}
