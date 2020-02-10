using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class TakilacakLastikPopUpViewModel : BaseViewModel
    {
        private INavigation _navigation;
        public TakilacakLastikPopUpPage Page { get; set; }

        private TakmaResponse _takilacakLastik;

        public TakmaResponse TakilacakLastik
        {
            get { return _takilacakLastik; }
            set
            {
                _takilacakLastik = value;
                OnPropertyChanged("TakilacakLastik");

            }
        }

        private ObservableCollection<TakmaResponse> _takilacakLastikListe;

        public ObservableCollection<TakmaResponse> TakilacakLastikListe
        {
            get { return _takilacakLastikListe; }
            set
            {
                _takilacakLastikListe = value;
                OnPropertyChanged("TakilacakLastikListe");
            }
        }

        public Command LastikleriTakCommand { get; set; }
        public TakilacakLastikPopUpViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LastikleriTakCommand = new Command(LastikleriTakAsync);
        }

        private void LastikleriTakAsync(object obj)
        {
            var test = TakilacakLastikListe;

        }
    }
}
