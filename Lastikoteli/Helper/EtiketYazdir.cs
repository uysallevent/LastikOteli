using Lastikoteli.Helper.Abstract;
using LinkOS.Plugin;
using LinkOS.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lastikoteli.Helper
{
    public class EtiketYazdir: IEtiketYazdir
    {
        protected IDiscoveredPrinter myPrinter;

        private void PrintLineMode()
        {
            IConnection connection = null;
            try
            {
                connection = myPrinter.Connection;
                connection.Open();
                IZebraPrinter printer = ZebraPrinterFactory.Current.GetInstance(connection);
                if ((!CheckPrinterLanguage(connection)) || (!PreCheckPrinterStatus(printer)))
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {

                    });
                    return;
                }

                SendZplReceipt(connection);

                if (true)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {

                    });
                    App.Current.MainPage.DisplayAlert("Uyarı", "Yazdırma işlemi başarılı", "Tamam");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if ((connection != null) && (connection.IsConnected))
                    connection.Close();
            }
        }

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

        public void SendZplReceipt(IConnection printerConnection)
        {
            string EtiketZPLKod = $"^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI28^XZ" +
                $"^XA" +
                $"^MMT" +
                $"^PW799" +
                $"^LL0639" +
                $"^LS0" +
                $"^FT216,122^A0N,87,86^FH\\^FD35TEST35^FS" +
                $"^FT265,301^A0N,31,31^FH\\^FDDenemeDıst^FS" +
                $"^FT57,241^A0N,31,31^FH\\^FDBayi / M\\81_teri :^FS" +
                $"^FT263,241^A0N,31,31^FH\\^FDDenemeUnvan^FS" +
                $"^FT57,362^A0N,31,31^FH\\^FDBRIDSTONE - " +
                $"205/" +
                $"55R" +
                $"16 - " +
                $"KIŞ - " +
                $"SNOWWAYS - " +
                $"ÖN SAĞ^FS" +
                $"^FT588,631^BQN,2,8" +
                $"^FH\\^FDMA,123456^FS" +
                $"^FT56,301^A0N,31,31^FH\\^FDFirma            :^FS" +
                $"^FT372,550^A0N,73,72^FH\\^FD1^FS" +
                $"^FT57,421^A0N,31,31^FH\\^FDAciklama       :^FS" +
                $"^FT57,542^A0N,45,45^FH\\^FDSaklama Kodu :^FS" +
                $"^FT262,179^A0N,31,31^FH\\^FDTestAdSoyad^FS" +
                $"^FT55,179^A0N,31,31^FH\\^FDTalep Eden     :^FS" +
                $"^FT265,421^A0N,31,31^FH\\^FDTestAçıklama^FS" +
                $"^PQ1,0,1,Y^XZ";


            printerConnection.Write(GetBytes(EtiketZPLKod));
        }
    }
}
