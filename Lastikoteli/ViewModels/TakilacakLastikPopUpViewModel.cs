using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
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
                if (value != null && _takilacakLastik.bytSec == true)
                    _takilacakLastik.bytSec = false;
                else
                    _takilacakLastik.bytSec = true;

                _takilacakLastik = null;

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

        public ICommand LastikleriTakCommand { get; set; }

        public TakilacakLastikPopUpViewModel(INavigation navigation, ObservableCollection<TakmaResponse> takilacakListe)
        {
            _navigation = navigation;
            TakilacakLastikListe = takilacakListe;
            LastikleriTakCommand = new Command(LastikleriTakAsync);
        }

        private void LastikleriTakAsync()
        {
            var test = TakilacakLastikListe;

        }
    }
}
