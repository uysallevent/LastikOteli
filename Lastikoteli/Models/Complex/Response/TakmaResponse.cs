using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class TakmaResponse : INotifyPropertyChanged
    {
        public int lngSaklamaKod { get; set; }
        public string txtPozisyon { get; set; }
        public string txtLastik { get; set; }
        public string txtRaf { get; set; }
        public int lngOTL { get; set; }
        public bool bytOTL { get; set; }
        private bool _bytSec;
        public bool bytSec
        {
            get => _bytSec;
            set
            {
                _bytSec = value;
                OnPropertyChanged("bytSec");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
