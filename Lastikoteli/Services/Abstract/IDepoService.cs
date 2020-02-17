using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Abstract
{
    public interface IDepoService
    {
        Task<ApiResponseGeneric<ObservableCollection<DepoDizilimResponse>>> DepoBilgiGetir(DepoDizilimRequest request);
    }
}
