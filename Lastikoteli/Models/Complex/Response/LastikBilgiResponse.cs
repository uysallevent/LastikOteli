using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lastikoteli.Models.Complex.Response
{
    public class LastikBilgiResponse : INotifyPropertyChanged
    {
        private ObservableCollection<MarkaBilgiResponse> _markaListe;
        public ObservableCollection<MarkaBilgiResponse> markaListe { get { return _markaListe; } set { _markaListe = value; OnPropertyChanged("markaListe"); } }


        private ObservableCollection<MarkaBilgiResponse> _tabanListe;
        public ObservableCollection<MarkaBilgiResponse> tabanListe { get { return _tabanListe; } set { _tabanListe = value; OnPropertyChanged("tabanListe"); } }



        private ObservableCollection<MarkaBilgiResponse> _kesitListe;
        public ObservableCollection<MarkaBilgiResponse> kesitListe { get { return _kesitListe; } set { _kesitListe = value; OnPropertyChanged("kesitListe"); } }



        private ObservableCollection<MarkaBilgiResponse> _capListe;
        public ObservableCollection<MarkaBilgiResponse> capListe { get { return _capListe; } set { _capListe = value; OnPropertyChanged("capListe"); } }


        private ObservableCollection<MarkaBilgiResponse> _mevsimListe;
        public ObservableCollection<MarkaBilgiResponse> mevsimListe { get { return _mevsimListe; } set { _mevsimListe = value; OnPropertyChanged("mevsimListe"); } }


        private ObservableCollection<MarkaBilgiResponse> _desenListe;
        public ObservableCollection<MarkaBilgiResponse> desenListe { get { return _desenListe; } set { _desenListe = value; OnPropertyChanged("desenListe"); } }


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
