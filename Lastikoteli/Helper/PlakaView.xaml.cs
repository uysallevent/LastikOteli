using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xfx;
using ZXing.Net.Mobile.Forms;

namespace Lastikoteli.Helper
{
    public partial class PlakaView : ContentView
    {
        ZXingScannerPage scanPage;
        public PlakaView()
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
                MessagingCenter.Send(this, "plakaBarcode", result.Text);

            });

        }


        public string PlakaEntryText
        {
            get
            {
                return (string)GetValue(PlakaEntryTextProperty);
            }
            set
            {

                SetValue(PlakaEntryTextProperty, value);

            }
        }

        public static readonly BindableProperty PlakaEntryTextProperty = BindableProperty.Create(
                                                  propertyName: "PlakaEntryText",
                                                  returnType: typeof(string),
                                                  declaringType: typeof(PlakaView),
                                                  defaultBindingMode: BindingMode.TwoWay,
                                                  propertyChanging: TitleTextPropertyChanged);

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PlakaView)bindable;
            control.PlakaEntryText = newValue.ToString();

        }

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            var xfxEntry = (XfxEntry)sender;

            xfxEntry.Text = xfxEntry.Text.ToUpper();
            PlakaEntryText = xfxEntry.Text;

            MessagingCenter.Send(this, "saklamaKodTemizle");
            MessagingCenter.Subscribe<SaklamaNoView>(this, "plakaTemizle", (s) =>
            {
                xfxEntry.Text = "";
                PlakaEntryText = "";
            });
            MessagingCenter.Subscribe<MusteriNoView>(this, "musteriNoTemizle", (s) =>
            {
                xfxEntry.Text = "";
                PlakaEntryText = "";
            });
        }




        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(scanPage);

        }
    }
}
