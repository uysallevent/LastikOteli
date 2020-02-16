using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class YeniSaklamaViewModel : BaseViewModel
    {
        public YeniSaklamaPlakaBilgileri PagePlakaBilgi { get; set; }
        public YeniSaklamaMarkaBilgi PageMarkaBilgi { get; set; }

        private MarkaBilgiRequest _markaBilgiRequest;
        public MarkaBilgiRequest markaBilgiReuqest
        {
            get
            {
                return _markaBilgiRequest;
            }
            set
            {
                _markaBilgiRequest = value;
                OnPropertyChanged("markaBilgiReuqest");

            }
        }

        private int _selectedIndex;
        public int selectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                if (_selectedIndex != null && _selectedIndex != -1)
                {
                    markaBilgiReuqest.txtMarka = markaListe[_selectedIndex].txtMarka;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedIndex");

            }
        }

        private bool _bytUrunTip;
        public bool bytUrunTip
        {
            get
            {
                return _bytUrunTip;
            }
            set
            {
                _bytUrunTip = value;
                OnPropertyChanged("bytUrunTip");
            }
        }

        private ObservableCollection<MarkaBilgiResponse> _markaListe;
        public ObservableCollection<MarkaBilgiResponse> markaListe
        {
            get
            {
                return _markaListe;
            }

            set
            {

                _markaListe = value;
                OnPropertyChanged("markaListe");
            }
        }

        private LastikBilgiResponse _lastikBilgileri;
        public LastikBilgiResponse lastikBilgileri
        {
            get
            {
                return _lastikBilgileri;
            }

            set
            {
                _lastikBilgileri = value;
                OnPropertyChanged("lastikBilgileri");
            }
        }

        public YeniSaklamaMarkaBilgi Page { get; set; }

        private INavigation _navigation;
        public ICommand GotoMusteriPopUpCommand { get; set; }
        public ICommand MarkaBilgiGetirCommand { get; set; }
        public YeniSaklamaViewModel(INavigation navigation)
        {
            _navigation = navigation;
            markaBilgiReuqest = new MarkaBilgiRequest();
            lastikBilgileri = new ObservableCollection<LastikBilgiResponse>();
            GotoMusteriPopUpCommand = new Command(async () => await GotoMusteriPopUpAsync());
            MarkaBilgiGetirCommand = new Command(async () => await MarkaBilgiGetirAsync());
            MarkaBilgiGetirCommand.Execute(true);
            MessagingCenter.Subscribe<MusteriAraPopUpViewModel, MusteriBilgileriResponse>(this, "yeniSaklamaSecilenMusteri", (s, e) =>
            {

            });
        }

        private async Task MarkaBilgiGetirAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                markaBilgiReuqest.lngUrunTip = !bytUrunTip ? 1 : 2;
                var result = await ParametreService.MarkaBilgiGetir(markaBilgiReuqest);
                if (result.StatusCode != 500)
                {
                    //markaListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    if (lastikBilgileri.markaListe.Count == 0)
                        lastikBilgileri.markaListe = result.Result;
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count == 0)
                        lastikBilgileri.tabanListe = result.Result;
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count > 0 && lastikBilgileri.kesitListe.Count == 0)
                        lastikBilgileri.kesitListe = result.Result;
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count > 0 && lastikBilgileri.kesitListe.Count > 0 && lastikBilgileri.capListe.Count == 0)
                        lastikBilgileri.capListe = result.Result;
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count == 0 && lastikBilgileri.kesitListe.Count > 0 && lastikBilgileri.capListe.Count > 0 && lastikBilgileri.mevsimListe.Count == 0)
                        lastikBilgileri.mevsimListe = result.Result;
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count == 0 && lastikBilgileri.kesitListe.Count > 0 && lastikBilgileri.capListe.Count > 0 && lastikBilgileri.mevsimListe.Count > 0 && lastikBilgileri.desenListe.Count == 0)
                        lastikBilgileri.desenListe = result.Result;

                    //markaListe = result.Result;
                }
                else
                {
                    markaListe = new ObservableCollection<MarkaBilgiResponse>();
                    await this.Page.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
                }

            }
            catch (Exception ex)
            {
                await this.Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GotoMusteriPopUpAsync()
        {
            PagePlakaBilgi.OpenPopup();
        }

    }
}
