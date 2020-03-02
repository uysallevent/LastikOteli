using Lastikoteli.Models.Complex.Response;
using Lastikoteli.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace Lastikoteli.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LastikRafIslemleriPopUpPage : PopupPage
    {
        LastikRafIslemleriPopUpViewModel lastikRafIslemleriPopUpViewModel;
        ZXingScannerPage scanPage;

        public LastikRafIslemleriPopUpPage(SaklamaBilgileriResponse saklamaBilgileri)
        {
            InitializeComponent();
            BindingContext = lastikRafIslemleriPopUpViewModel = new LastikRafIslemleriPopUpViewModel(saklamaBilgileri);
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += ScanPage_OnScanResult;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }

        private void QRCodeImageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(scanPage);
        }

        private void ScanPage_OnScanResult(ZXing.Result result)
        {
            scanPage.IsScanning = false;
            Device.BeginInvokeOnMainThread(() =>
            {
                App.Current.MainPage.Navigation.PopModalAsync(true);

                xfxEntryRafKod.Text = result.Text;
            });
        }
    }
}