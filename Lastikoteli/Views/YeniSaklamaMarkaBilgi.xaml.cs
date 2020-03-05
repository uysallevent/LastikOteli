using Lastikoteli.Helper;
using Lastikoteli.Helper.Abstract;
using Lastikoteli.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xfx;

namespace Lastikoteli.Views
{
    public partial class YeniSaklamaMarkaBilgi : ContentPage
    {
        YeniSaklamaViewModel yeniSaklamaView;
        private DoubleClickControl _doubleClickControl;

        public YeniSaklamaMarkaBilgi()
        {
            InitializeComponent();
            BindingContext = yeniSaklamaView = new YeniSaklamaViewModel(this.Navigation);
            _doubleClickControl = new DoubleClickControl(this.Navigation);

            MessagingCenter.Subscribe<YeniSaklamaMarkaBilgileriViewModel>(this, "detayScrollUp", (s) =>
            {
                Device.BeginInvokeOnMainThread(async () => await scrollDetay.ScrollToAsync(0, 0, true));
            });
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            var btn = (ImageButton)sender;
            switch (btn.StyleId)
            {
                case "btnOnSol":
                    btn.BackgroundColor = Color.DarkOrange;
                    btnOnSag.BackgroundColor = Color.White;
                    btnArkaSol.BackgroundColor = Color.White;
                    btnArkaSag.BackgroundColor = Color.White;
                    btnDigerSol.BackgroundColor = Color.White;
                    btnDigerSag.BackgroundColor = Color.White;
                    break;
                case "btnOnSag":
                    btnOnSol.BackgroundColor = Color.White;
                    btn.BackgroundColor = Color.DarkOrange;
                    btnArkaSol.BackgroundColor = Color.White;
                    btnArkaSag.BackgroundColor = Color.White;
                    btnDigerSol.BackgroundColor = Color.White;
                    btnDigerSag.BackgroundColor = Color.White;
                    break;
                case "btnArkaSol":
                    btnOnSol.BackgroundColor = Color.White;
                    btnOnSag.BackgroundColor = Color.White;
                    btn.BackgroundColor = Color.DarkOrange;
                    btnArkaSag.BackgroundColor = Color.White;
                    btnDigerSol.BackgroundColor = Color.White;
                    btnDigerSag.BackgroundColor = Color.White;
                    break;
                case "btnArkaSag":
                    btnOnSol.BackgroundColor = Color.White;
                    btnOnSag.BackgroundColor = Color.White;
                    btnArkaSol.BackgroundColor = Color.White;
                    btn.BackgroundColor = Color.DarkOrange;
                    btnDigerSol.BackgroundColor = Color.White;
                    btnDigerSag.BackgroundColor = Color.White;
                    break;
                case "btnDigerSol":
                    btnOnSol.BackgroundColor = Color.White;
                    btnOnSag.BackgroundColor = Color.White;
                    btnArkaSol.BackgroundColor = Color.White;
                    btnArkaSag.BackgroundColor = Color.White;
                    btn.BackgroundColor = Color.DarkOrange;
                    btnDigerSag.BackgroundColor = Color.White;
                    break;
                case "btnDigerSag":
                    btnOnSol.BackgroundColor = Color.White;
                    btnOnSag.BackgroundColor = Color.White;
                    btnArkaSol.BackgroundColor = Color.White;
                    btnArkaSag.BackgroundColor = Color.White;
                    btnDigerSol.BackgroundColor = Color.White;
                    btn.BackgroundColor = Color.DarkOrange;
                    break;

            }

        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var swUrunTip = (Switch)sender;
            (BindingContext as YeniSaklamaMarkaBilgileriViewModel).detay.bytUrunTip = swUrunTip.IsToggled;
            (BindingContext as YeniSaklamaMarkaBilgileriViewModel).detay.LNGURUNTIP = (swUrunTip.IsToggled) ? 2 : 1;
            if (swUrunTip.IsToggled)
            {
                stackBrisa.IsVisible = false;
                stackBrisa.IsEnabled = false;

                stackDiger.IsVisible = true;
                stackDiger.IsEnabled = true;
            }
            else
            {
                stackBrisa.IsVisible = true;
                stackBrisa.IsEnabled = true;

                stackDiger.IsVisible = false;
                stackDiger.IsEnabled = false;
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await _doubleClickControl.PopUpPushAsync(new DepoSecimPopUpPage());

           // PopupNavigation.PushAsync(new DepoSecimPopUpPage());
        }

        private void isOtl_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var swOTL = (Switch)sender;
            if (BindingContext != null)
                (BindingContext as YeniSaklamaMarkaBilgileriViewModel).detay.ISOTL = (swOTL.IsToggled) ? 1 : 0;
        }

        private void bytDurum_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var swOTL = (Switch)sender;
            if (BindingContext != null)
                (BindingContext as YeniSaklamaMarkaBilgileriViewModel).detay.BYTDURUM = (swOTL.IsToggled) ? 1 : 0;
        }

        private void uretim_XfxEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entryUretim = (XfxEntry)sender;
            if (BindingContext != null)
                (BindingContext as YeniSaklamaMarkaBilgileriViewModel).detay.TXTDOTURETIM = entryUretim.Text;
        }

        private void fabrika_XfxEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entryFabrika = (XfxEntry)sender;
            if (BindingContext != null)
                (BindingContext as YeniSaklamaMarkaBilgileriViewModel).detay.TXTDOTFABRIKA = entryFabrika.Text;
        }

        private void hafta_XfxEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entryHafta = (XfxEntry)sender;
            if (BindingContext != null)
                (BindingContext as YeniSaklamaMarkaBilgileriViewModel).detay.TXTDOTHAFTA = entryHafta.Text;
        }

        private void disDerinligi_XfxEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entryDD = (XfxEntry)sender;
            if (BindingContext != null)
                (BindingContext as YeniSaklamaMarkaBilgileriViewModel).detay.txtDisDerinligi = entryDD.Text;
        }
    }
}
