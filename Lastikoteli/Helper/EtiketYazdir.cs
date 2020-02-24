﻿using Lastikoteli.Helper.Abstract;
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
            foreach (var item in request.lastikListesi)
            {
                var desenKodu = request.desenKodu
                    .Replace("[PLAKA]", item.txtPlaka)
                    .Replace("[HIZMETVEREN]", item.txtDistAdi)
                    .Replace("[MUSTERISTRING]", item.txtUnvan)
                    .Replace("[MARKASTRING]", item.txtMarka)
                    .Replace("[SAKLAMAKODU]", "--SK--" + item.lngSaklamaBaslik.ToString())
                    .Replace("[TALEPEDENBAYII]", item.txtKullaniciAdiSoyad)
                    .Replace("[ACIKLAMA]", item.txtAciklama);
                printerConnection.Write(GetBytes(desenKodu));
            }
        }
    }
}