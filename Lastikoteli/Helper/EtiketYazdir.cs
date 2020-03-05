using Lastikoteli.Helper.Abstract;
using Lastikoteli.Models.Complex.Request;
using LinkOS.Plugin;
using LinkOS.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lastikoteli.Helper
{
    public class EtiketYazdir : IEtiketYazdir
    {
        protected IDiscoveredPrinter myPrinter;

        public bool CheckPrinterLanguage(IConnection connection)
        {
            if (!connection.IsConnected)
                connection.Open();

            //  Check the current printer language
            byte[] response = connection.SendAndWaitForResponse(GetBytes("! U1 getvar \"device.languages\"\r\n"), 500, 100);
            string language = Encoding.UTF8.GetString(response, 0, response.Length);
            if (language.Contains("line_print"))
            {
                //ShowAlert("Switching printer to ZPL Control Language.", "Notification");
            }
            // printer is already in zpl mode
            else if (language.Contains("zpl"))
            {
                return true;
            }

            //  Set the printer command languege
            connection.Write(GetBytes("! U1 setvar \"device.languages\" \"zpl\"\r\n"));
            response = connection.SendAndWaitForResponse(GetBytes("! U1 getvar \"device.languages\"\r\n"), 500, 100);
            language = Encoding.UTF8.GetString(response, 0, response.Length);
            if (!language.Contains("zpl"))
            {
                App.Current.MainPage.DisplayAlert("Uyarı", "ZPL destekli yazıcı bulunamadı", "Tamam");
                return false;
            }
            return true;
        }

        protected static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length];
            bytes = Encoding.UTF8.GetBytes(str);
            return bytes;
        }

        public bool PreCheckPrinterStatus(IZebraPrinter printer)
        {
            // Check the printer status
            IPrinterStatus status = printer.CurrentStatus;
            if (!status.IsReadyToPrint)
            {
                App.Current.MainPage.DisplayAlert("Uyarı", "Bu yazıcı kullanılamıyor." + status.Status, "Tamam");
                return false;
            }
            return true;
        }

        public void SendZplReceipt(IConnection printerConnection, PrintRequest request)
        {
            if (request.lastikEtiketlerBilgi != null && request.lastikEtiketlerBilgi.Count > 0)
            {
                foreach (var item in request.lastikEtiketlerBilgi)
                {
                    printerConnection.Write(GetBytes(item.Value));
                }
            }
            else if (request.siraKolayKodEtiketBilgileri != null && !string.IsNullOrEmpty(request.siraKolayKodEtiketBilgileri.desenKodu))
            {
                string desenKodu = "";
                for (int i = 0; i < request.siraKolayKodEtiketBilgileri.rafKolayKodListesi.Count; i += 2)
                {
                    if (i == request.siraKolayKodEtiketBilgileri.rafKolayKodListesi.Count - 1)
                        desenKodu = request.siraKolayKodEtiketBilgileri.desenKodu
                            .Replace("[RafKK1]", request.siraKolayKodEtiketBilgileri.rafKolayKodListesi[i].txtKod);

                    desenKodu = request.siraKolayKodEtiketBilgileri.desenKodu
                        .Replace("[RafKK1]", request.siraKolayKodEtiketBilgileri.rafKolayKodListesi[i].txtKod)
                        .Replace("[RafKK2]", request.siraKolayKodEtiketBilgileri.rafKolayKodListesi[i].txtKod);

                    printerConnection.Write(GetBytes(desenKodu));
                }
            }

        }
    }
}
