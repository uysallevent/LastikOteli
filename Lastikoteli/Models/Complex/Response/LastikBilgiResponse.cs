using System;
using System.Collections.ObjectModel;

namespace Lastikoteli.Models.Complex.Response
{
    public class LastikBilgiResponse
    {
        public ObservableCollection<MarkaBilgiResponse> markaListe { get; set; }
        public ObservableCollection<MarkaBilgiResponse> tabanListe { get; set; }
        public ObservableCollection<MarkaBilgiResponse> kesitListe { get; set; }
        public ObservableCollection<MarkaBilgiResponse> capListe { get; set; }
        public ObservableCollection<MarkaBilgiResponse> mevsimListe { get; set; }
        public ObservableCollection<MarkaBilgiResponse> desenListe { get; set; }

    }
}
