using Lastikoteli.Models.Complex.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class MusteriAraPopUpViewModel : BaseViewModel
    {

        private CustomViewMusteriBilgileriRequest _customViewMusteriBilgileriRequest;

        private bool _bytUnvan;
        public bool bytunvan
        {
            get { return _bytUnvan; }
            set
            {
                _bytUnvan = value;
                OnPropertyChanged("bytunvan");
            }
        }

        private bool _bytErpKod;
        public bool bytErpKod
        {
            get { return _bytErpKod; }
            set
            {
                _bytErpKod = value;
                OnPropertyChanged("bytErpKod");
            }
        }

        private bool _bytLngKod;
        public bool bytLngKod
        {
            get { return _bytLngKod; }
            set
            {
                _bytLngKod = value;
                OnPropertyChanged("bytLngKod");
            }
        }

        public ICommand musteriAraCommand { get; set; }


        public CustomViewMusteriBilgileriRequest CustomViewMusteriBilgileriRequest
        {
            get { return _customViewMusteriBilgileriRequest; }
            set
            {
                _customViewMusteriBilgileriRequest = value;
                OnPropertyChanged("CustomViewMusteriBilgileriRequest");
            }
        }


        public MusteriAraPopUpViewModel()
        {
            bytunvan = true;
            bytErpKod = false;
            bytLngKod = false;
            musteriAraCommand = new Command(async () => await musteriAraAsync());
        }

        private async Task musteriAraAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = SaklamaService.MusteriListesi(
                    new SaklamaMusteriRequest
                    {
                        Filter = new CustomViewMusteriBilgileriRequest
                        {

                        },
                        Paging = new PagingRequest { Sayfa = -1 }
                    });

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
