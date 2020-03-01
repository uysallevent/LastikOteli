using Lastikoteli.Helper.Abstract;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using Rg.Plugins.Popup.Services;
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
    public class DepoSecimPopUpViewModel : BaseViewModel
    {
        public DepoSecimPopUpPage Page { get; set; }

        private DepoDizilimRequest _selectedDepoBilgi;
        public DepoDizilimRequest selectedDepoBilgi
        {
            get
            {
                return _selectedDepoBilgi;
            }
            set
            {
                _selectedDepoBilgi = value;
                OnPropertyChanged("selectedDepoBilgi");
            }
        }

        private DepoDizilimResponse _selectedDepo;
        public DepoDizilimResponse selectedDepo
        {
            get { return _selectedDepo; }
            set
            {
                _selectedDepo = value;
                if (_selectedDepo != null)
                {
                    if (selectedDepoBilgi.lngDepoSira == 5)
                    {
                        MessagingCenter.Send(this, "selectedRaf", _selectedDepo);
                        PopupNavigation.PopAsync(true);
                        return;
                    }

                    selectedDepoBilgi.lngDepoSira += 1;
                    selectedDepoBilgi.lngKod = _selectedDepo.lngKod;
                    DepoBilgileriGetirCommand.Execute(true);

                }
                OnPropertyChanged("selectedDepo");

            }
        }

        public List<int> depoSira { get; set; }


        private ObservableCollection<DepoDizilimResponse> _depoBilgiList;
        public ObservableCollection<DepoDizilimResponse> depoBilgiList
        {
            get { return _depoBilgiList; }
            set
            {
                _depoBilgiList = value;
                OnPropertyChanged("depoBilgiList");
            }
        }

        public ICommand DepoBilgileriGetirCommand { get; set; }

        public ICommand BackGestureCommand { get; set; }
        public DepoSecimPopUpViewModel()
        {
            depoSira = new List<int>();
            depoSira.Add(0);
            depoSira.Add(0);
            depoSira.Add(0);
            depoSira.Add(0);
            selectedDepoBilgi = new DepoDizilimRequest() { lngDistKod = App.sessionInfo.lngDistkod, lngDepoSira = 1 };
            DepoBilgileriGetirCommand = new Command(async () => await DepoBilgileriGetirAsync());
            BackGestureCommand = new Command(async () => await BackGestureAsync());
            DepoBilgileriGetirCommand.Execute(true);

        }

        private async Task BackGestureAsync()
        {
            if (selectedDepoBilgi.lngDepoSira > 1 && selectedDepoBilgi.lngDepoSira <= 5)
            {
                selectedDepoBilgi.lngDepoSira -= 1;
                if (selectedDepoBilgi.lngDepoSira > 1)
                    selectedDepoBilgi.lngKod = depoSira[selectedDepoBilgi.lngDepoSira - 2];
                await DepoBilgileriGetirAsync();
            }
            else
                DependencyService.Get<IToastService>().ToastMessage("Depo'dan daha geriye gidemezsiniz");
        }

        private async Task DepoBilgileriGetirAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;


                var result = await DepoService.DepoBilgiGetir(selectedDepoBilgi);
                if (result.StatusCode != 500)
                {
                    depoBilgiList = new ObservableCollection<DepoDizilimResponse>(result.Result);
                    if (selectedDepoBilgi.lngDepoSira == 2)
                        depoSira[0] = selectedDepoBilgi.lngKod ?? 0;
                    if (selectedDepoBilgi.lngDepoSira == 3)
                        depoSira[1] = selectedDepoBilgi.lngKod ?? 0;
                    if (selectedDepoBilgi.lngDepoSira == 4)
                        depoSira[2] = selectedDepoBilgi.lngKod ?? 0;
                    if (selectedDepoBilgi.lngDepoSira == 5)
                        depoSira[3] = selectedDepoBilgi.lngKod ?? 0;
                }
                else
                {
                    depoBilgiList = new ObservableCollection<DepoDizilimResponse>();
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
    }
}
