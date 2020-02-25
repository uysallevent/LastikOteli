using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lastikoteli.Models.Complex.Response
{
    public class LastikBilgiListResponse
    {
        public int lngLastikYon { get; set; }
        public ObservableCollection<LastikBilgiResponse> liste { get; set; }
    }
}
