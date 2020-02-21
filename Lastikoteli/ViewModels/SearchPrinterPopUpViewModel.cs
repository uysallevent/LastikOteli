using Lastikoteli.Helper;
using Lastikoteli.Helper.Abstract;
using Lastikoteli.Models.Enums;
using Lastikoteli.Views;
using LinkOS.Plugin;
using LinkOS.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class SearchPrinterPopUpViewModel : BaseViewModel
    {
        public SearchPrinterPopupPage Page { get; set; }
        private EtiketYazdir etiketYazdir;
        protected IDiscoveredPrinter myPrinter;

        private string _statusText;
        public string statusText
        {
            get { return _statusText; }
            set { SetProperty<string>(ref _statusText, value); }
        }


        public void UpdateStatusText(string message)
        {
            statusText = message;
            OnPropertyChanged("statustext");
        }

        private IDiscoveredPrinter _discoveredPrinter;

        public IDiscoveredPrinter discoveredPrinter
        {
            get { return _discoveredPrinter; }
            set
            {
                _discoveredPrinter = value;
                if (_discoveredPrinter != null)
                {
                    myPrinter = _discoveredPrinter;
                    new Task(new Action(() =>
                    {
                        PrintLineMode();
                    })).Start();
                }
            }
        }

        private void PrintLineMode()
        {
            IConnection connection = null;
            try
            {
                connection = myPrinter.Connection;
                connection.Open();
                IZebraPrinter printer = ZebraPrinterFactory.Current.GetInstance(connection);
                if ((!etiketYazdir.CheckPrinterLanguage(connection)) || (!etiketYazdir.PreCheckPrinterStatus(printer)))
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {

                    });
                    return;
                }

                EtiketYazdir.SendZplReceipt(connection);

                etiketYazdir.SendZplReceipt(connection);

                if (true)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {

                    });
                    Page.DisplayAlert("Uyarı", "Yazdırma işlemi başarılı", "Tamam");
                }
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() =>
                {

                });

                Page.DisplayAlert("Uyarı", "Yazdırma işlemi sırasında bir hata oluştu", "Tamam");
            }
            finally
            {
                if ((connection != null) && (connection.IsConnected))
                    connection.Close();
            }
        }


        private IList<IDiscoveredPrinter> _printerList;
        public IList<IDiscoveredPrinter> printerList
        {
            get { return _printerList; }
            set
            {
                _printerList = value;
                OnPropertyChanged("printerList");
            }
        }
        public void StartDiscovery(ConnectionType connectionType)
        {
            UpdateStatusText($"Yazıcılar aranıyor. Bağlantı tipi {connectionType.ToString()}");
            try
            {
                switch (connectionType)
                {
                    case ConnectionType.Bluetooth:
                        DependencyService.Get<IPrinterDiscovery>().FindBluetoothPrinters(new DiscoveryHandlerImplementation(this, ConnectionType.Bluetooth));
                        break;

                    case ConnectionType.Network:
                        NetworkDiscoverer.Current.LocalBroadcast(new DiscoveryHandlerImplementation(this, ConnectionType.Network));
                        break;

                    case ConnectionType.USB:
                        DependencyService.Get<IPrinterDiscovery>().FindUsbPrinters(new DiscoveryHandlerImplementation(this, ConnectionType.USB));
                        break;
                }
            }
            catch (Exception e)
            {
                string errorMessage = $"Yazıcı arama hatası. Bağlantı tipi {nameof(connectionType)} {e.Message}";
                //ShowErrorAlert(errorMessage);
            }
        }

        public SearchPrinterPopUpViewModel()
        {
            etiketYazdir = new EtiketYazdir();
            printerList = new ObservableCollection<IDiscoveredPrinter>();
            StartPrinterDiscovery();
        }

        public void StartPrinterDiscovery()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (printerList != null && printerList.Count > 0)
                {
                    printerList.Clear();
                }
                StartDiscovery(ConnectionType.Network);
            });
        }

        public class DiscoveryHandlerImplementation : IDiscoveryHandler
        {
            private SearchPrinterPopUpViewModel selectPrinterPageViewModel;
            private ConnectionType connectionType;

            public DiscoveryHandlerImplementation(SearchPrinterPopUpViewModel selectPrinterPage, ConnectionType connectionType)
            {
                this.selectPrinterPageViewModel = selectPrinterPage;
                this.connectionType = connectionType;
            }

            public void DiscoveryError(string message)
            {
                selectPrinterPageViewModel.Page.DisplayAlert("Uyarı", message, "Tamam");

                if (connectionType == ConnectionType.USB)
                {
                    selectPrinterPageViewModel.StartDiscovery(ConnectionType.Bluetooth);
                }
                else if (connectionType == ConnectionType.Bluetooth)
                {
                    selectPrinterPageViewModel.StartDiscovery(ConnectionType.Network);
                }
                else
                    selectPrinterPageViewModel.UpdateStatusText("Yazıcı araması bitti");
            }

            public void DiscoveryFinished()
            {
                if (connectionType == ConnectionType.USB)
                {
                    selectPrinterPageViewModel.StartDiscovery(ConnectionType.Bluetooth);
                }
                else if (connectionType == ConnectionType.Bluetooth)
                {
                    selectPrinterPageViewModel.StartDiscovery(ConnectionType.Network);
                }
                else
                {
                    if (selectPrinterPageViewModel.printerList == null || selectPrinterPageViewModel.printerList.Count == 0)
                        selectPrinterPageViewModel.Page.DisplayAlert("Uyarı", "Yazıcı bulunamadı", "Tamam");
                }
                selectPrinterPageViewModel.UpdateStatusText("Yazıcı araması bitti");
            }

            public void FoundPrinter(IDiscoveredPrinter discoveredPrinter)
            {

                if (!selectPrinterPageViewModel.printerList.Contains(discoveredPrinter))
                {
                    selectPrinterPageViewModel.printerList.Add(discoveredPrinter);
                }
            }
        }
    }


}
