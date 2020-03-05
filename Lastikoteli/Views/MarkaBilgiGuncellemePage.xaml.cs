using Lastikoteli.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xfx;

namespace Lastikoteli.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarkaBilgiGuncellemePage : ContentPage
    {
        public MarkaBilgiGuncellemePage()
        {
            InitializeComponent();

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

        private void urunTip_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var swUrunTip = (Switch)sender;
            (BindingContext as SaklamaMarkaBilgiGuncelleme).detay.bytUrunTip = swUrunTip.IsToggled;
            (BindingContext as SaklamaMarkaBilgiGuncelleme).detay.LNGURUNTIP = (swUrunTip.IsToggled) ? 2 : 1;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as SaklamaMarkaBilgiGuncelleme).DevamButonuCommand.Execute(true);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new DepoSecimPopUpPage());
        }

        private void isOtl_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var swOTL = (Switch)sender;
            (BindingContext as SaklamaMarkaBilgiGuncelleme).detay.ISOTL = (swOTL.IsToggled) ? 1 : 0;
        }

        private void bytDurum_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var swBytDurum = (Switch)sender;
            (BindingContext as SaklamaMarkaBilgiGuncelleme).detay.BYTDURUM = (swBytDurum.IsToggled) ? 1 : 0;
        }

        private void xfxEntryDis_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entryDD = (XfxEntry)sender;
            (BindingContext as SaklamaMarkaBilgiGuncelleme).detay.txtDisDerinligi = entryDD.Text;
        }
    }
}