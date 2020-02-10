﻿using Lastikoteli.Models.Complex.Response;
using Lastikoteli.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lastikoteli.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YeniTakma : ContentPage
    {
        YeniTakmaViewModel _yeniTakmaViewModel;
        public YeniTakma(int saklamaBaslik)
        {
            InitializeComponent();
            BindingContext = _yeniTakmaViewModel = new YeniTakmaViewModel(this.Navigation, saklamaBaslik);
            (BindingContext as YeniTakmaViewModel).Page = this;
        }

        public async void OpenPopup(ObservableCollection<TakmaResponse> lastikListe)
        {
            await PopupNavigation.PushAsync(new TakilacakLastikPopUpPage(lastikListe));
        }
    }
}