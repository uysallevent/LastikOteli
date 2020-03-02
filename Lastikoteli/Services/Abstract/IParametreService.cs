using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;

namespace Lastikoteli.Services.Abstract
{
    public interface IParametreService
    {
        Task<ApiResponseGeneric<ObservableCollection<MarkaBilgiResponse>>> MarkaBilgiGetir(MarkaBilgiRequest request);
        Task<ApiResponseGeneric<ObservableCollection<KeyValuePair<string, string>>>> DesenBilgileriGetir(DesenRequest request);
        Task<ApiResponseGeneric<SiraKolayKodDesenBilgiResponse>> SiraKolayKodDesenBilgiGetir();
    }
}
