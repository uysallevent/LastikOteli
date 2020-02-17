using Lastikoteli.Helper.Abstract;
using Lastikoteli.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lastikoteli.Views
{
    public partial class YeniSaklamaMarkaBilgi : ContentPage
    {
        YeniSaklamaViewModel yeniSaklamaViewModel;
        public YeniSaklamaMarkaBilgi()
        {
            InitializeComponent();
            BindingContext = yeniSaklamaViewModel = new YeniSaklamaViewModel(this.Navigation);
            (BindingContext as YeniSaklamaViewModel).Page = this;
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
                    DependencyService.Get<IToastService>().ToastMessage("Toast Message");
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
            var sw = (Switch)sender;
            sw.SetBinding(Switch.IsToggledProperty, "bytUrunTip");
            if (sw.IsToggled)
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

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new DepoSecimPopUpPage());
        }
    }
}
