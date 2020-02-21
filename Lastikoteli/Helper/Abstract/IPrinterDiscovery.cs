using LinkOS.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Helper.Abstract
{
    public interface IPrinterDiscovery
    {
        void FindBluetoothPrinters(IDiscoveryHandler handler);

        void FindUsbPrinters(IDiscoveryHandler handler);

        void RequestUsbPermission(IDiscoveredPrinterUsb printer);

        void CancelDiscovery();
    }
}
