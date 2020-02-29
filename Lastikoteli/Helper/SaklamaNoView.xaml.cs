using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xfx;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace Lastikoteli.Helper
{
    public partial class SaklamaNoView : ContentView
    {
        ZXingScannerPage scanPage;

        public SaklamaNoView()
        {
            InitializeComponent();
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += ScanPage_OnScanResult;
        }

        private void ScanPage_OnScanResult(ZXing.Result result)
        {

            scanPage.IsScanning = false;
            Device.BeginInvokeOnMainThread(() =>
            {
                App.Current.MainPage.Navigation.PopModalAsync(true);
                if (!string.IsNullOrEmpty(result.Text))
                {
                    string resultText = result.Text;
                    for (int i = resultText.Length - 1; i >= 0; i--)
                        if (!char.IsNumber(resultText[i]))
                            resultText = resultText.Remove(i, 1);

                    xfxSaklamaNoEntry.Text = resultText;
                }

                MessagingCenter.Send(this, "saklamaKodBarcode", result.Text);
            });

        }

        public string SaklamaNoEntryText
        {
            get { return (string)GetValue(SaklamaNoEntryTextProperty); }
            set { SetValue(SaklamaNoEntryTextProperty, value); }
        }

        public static readonly BindableProperty SaklamaNoEntryTextProperty = BindableProperty.Create(
                                                  propertyName: "SaklamaNoEntryText",
                                                  returnType: typeof(string),
                                                  declaringType: typeof(SaklamaNoView),
                                                  defaultBindingMode: BindingMode.TwoWay);

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            var xfxEntry = (XfxEntry)sender;
            //if (!StringFormatControl.IsAllCharNumeric(xfxEntry.Text))
            //    xfxEntry.Text = xfxEntry.Text.Remove(xfxEntry.Text.Length - 1);

            SaklamaNoEntryText = xfxEntry.Text;

            MessagingCenter.Send(this, "plakaTemizle");
            MessagingCenter.Subscribe<PlakaView>(this, "saklamaKodTemizle", (s) =>
            {
                xfxEntry.Text = "";
                SaklamaNoEntryText = "";
            });
            MessagingCenter.Subscribe<MusteriNoView>(this, "musteriNoTemizle", (s) =>
            {
                xfxEntry.Text = "";
                SaklamaNoEntryText = "";
            });


        }

        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(scanPage);
        }
    }
}
