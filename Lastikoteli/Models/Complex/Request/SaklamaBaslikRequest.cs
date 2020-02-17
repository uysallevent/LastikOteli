using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lastikoteli.Models.Complex.Request
{
    public class SaklamaBaslikRequest : INotifyPropertyChanged
    {
        public int? LNGKOD { get; set; }
        public int LNGDISTKOD { get; set; }
        public int? LNGFILOKOD { get; set; }
        public int? LNGMUSTERIKOD { get; set; }
        public string TXTMUSTERIERPKOD { get; set; }
        public string TXTMUSTERIUNVAN { get; set; }
        public string TXTSOFORADSOYAD { get; set; }
        public string TXTPLAKA { get; set; }
        public Int64 LNGARACKM { get; set; }
        public string TXTTCKIMLIKNO { get; set; }
        public string TXTVN { get; set; }
        public string TXTCEPTEL { get; set; }
        public string TXTEMAIL { get; set; }
        public string TXTACIKLAMA { get; set; }
        public int BYTDURUM { get; set; }
        public int LNGSONISLEMYAPANKULLANICI { get; set; }
        /// <summary>
        /// Muhtelif kayıt olma durumunda adet bilgisi gönderilir.
        /// Olmama durumunda null gelir
        /// </summary>
        public int? LNGADET { get; set; }

        private ObservableCollection<SaklamaDetayRequest> _detayListe;
        public ObservableCollection<SaklamaDetayRequest> detayListe
        {
            get
            {
                return _detayListe;
            }
            set
            {
                _detayListe = value;
                OnPropertyChanged("detayListe");
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
