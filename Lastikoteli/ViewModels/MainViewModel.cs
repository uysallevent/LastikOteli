﻿using System;
using System.Threading.Tasks;
using Lastikoteli.Helper;
using Lastikoteli.Views;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private DoubleClickControl _doubleClickControl;

        public Command gotoIsListesiPageCommand { get; set; }
        public Command gotoHavuzIslemleriPageCommand { get; set; }
        public Command gotoDepoIslemleriPageCommand { get; set; }
        public Command gotoKayitGuncellemePageCommand { get; set; }

        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
            gotoIsListesiPageCommand = new Command(async () => await GotoIsListesiPage());
            gotoHavuzIslemleriPageCommand = new Command(async () => await gotoHavuzIslemleriPage());
            gotoDepoIslemleriPageCommand = new Command(async () => await gotoDepoIslemleriPage());
            gotoKayitGuncellemePageCommand = new Command(async () => await gotoKayitGuncellemePage());


        }

        private async Task gotoKayitGuncellemePage()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _doubleClickControl.PushAsync(new KayitGuncellemePage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", $"Bir hata oluştu {ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task gotoHavuzIslemleriPage()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _doubleClickControl.PushAsync(new HavuzIslemleriTabbedPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", $"Bir hata oluştu {ex.Message}", "Tamam");

            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task gotoDepoIslemleriPage()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _doubleClickControl.PushAsync(new DepoIslemleriPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", $"Bir hata oluştu {ex.Message}", "Tamam");

            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GotoIsListesiPage()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _doubleClickControl.PushAsync(new IsListesiAraPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", $"Bir hata oluştu {ex.Message}", "Tamam");

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
