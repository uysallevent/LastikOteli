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
        public int selectedMarkaIndex
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
                    markaBilgiReuqest.txtMarka = lastikBilgileri.markaListe[_selectedIndex].txtMarka;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedMarkaIndex");

            }
        }
        public int selectedTabanIndex
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
                    markaBilgiReuqest.txtTaban = lastikBilgileri.tabanListe[_selectedIndex].txtTaban;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedTabanIndex");

            }
        }
        public int selectedKesitIndex
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
                    markaBilgiReuqest.txtKesit = lastikBilgileri.kesitListe[_selectedIndex].txtKesit;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedKesitIndex");

            }
        }
        public int selectedCapIndex
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
                    markaBilgiReuqest.txtCap = lastikBilgileri.capListe[_selectedIndex].txtCap;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedCapIndex");
            }
        }
        public int selectedMevsimIndex
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
                    markaBilgiReuqest.txtMevsim = lastikBilgileri.mevsimListe[_selectedIndex].txtMevsim;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedMevsimIndex");

            }
        }
        public int selectedDesenIndex
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
                    markaBilgiReuqest.txtDesen = lastikBilgileri.desenListe[_selectedIndex].txtDesen;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedDesenIndex");

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
        public ICommand DisDerinligiKontrolCommand { get; set; }
        public YeniSaklamaViewModel(INavigation navigation)
        {
            _navigation = navigation;
            markaBilgiReuqest = new MarkaBilgiRequest();
            lastikBilgileri = new LastikBilgiResponse();
            GotoMusteriPopUpCommand = new Command(async () => await GotoMusteriPopUpAsync());
            MarkaBilgiGetirCommand = new Command(async () => await MarkaBilgiGetirAsync());
            DisDerinligiKontrolCommand = new Command(async()=>await DisDerinligiAsync());
            MarkaBilgiGetirCommand.Execute(true);
            MessagingCenter.Subscribe<MusteriAraPopUpViewModel, MusteriBilgileriResponse>(this, "yeniSaklamaSecilenMusteri", (s, e) =>
            {

            });
        }

        private async Task DisDerinligiAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await SaklamaService.YasalDisDerinligiGetir();
                if (result.StatusCode != 500)
                {

                }
                else
                    await this.Page.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");

            }
            catch (Exception)
            {
                await this.Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
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
                    if (lastikBilgileri.markaListe == null || lastikBilgileri.markaListe.Count == 0)
                        lastikBilgileri.markaListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    else if (lastikBilgileri.markaListe.Count > 0 && (lastikBilgileri.tabanListe == null || lastikBilgileri.tabanListe.Count == 0))
                        lastikBilgileri.tabanListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count > 0 && (lastikBilgileri.kesitListe == null || lastikBilgileri.kesitListe.Count == 0))
                        lastikBilgileri.kesitListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count > 0 && lastikBilgileri.kesitListe.Count > 0 && (lastikBilgileri.capListe == null || lastikBilgileri.capListe.Count == 0))
                        lastikBilgileri.capListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count > 0 && lastikBilgileri.kesitListe.Count > 0 && lastikBilgileri.capListe.Count > 0 && (lastikBilgileri.mevsimListe == null || lastikBilgileri.mevsimListe.Count == 0))
                        lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count > 0 && lastikBilgileri.kesitListe.Count > 0 && lastikBilgileri.capListe.Count > 0 && lastikBilgileri.mevsimListe.Count > 0 && (lastikBilgileri.desenListe == null || lastikBilgileri.desenListe.Count == 0))
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
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
