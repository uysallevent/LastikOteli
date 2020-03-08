using Lastikoteli.Helper.ServiceHelper;
using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Concrete
{
    public class DepoService : ServiceManager, IDepoService
    {
        public async Task<ApiResponseGeneric<ObservableCollection<DepoDizilimResponse>>> DepoBilgiGetir(DepoDizilimRequest request)
        {
            var Client = await GetClient();
            var response = await Client.GetAsync(apiUrl + "/api/Raf/DepoBilgileriGetir" + DepoBilgiQuery(request));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<ObservableCollection<DepoDizilimResponse>>(responseContent));
        }

        public async Task<ApiResponseGeneric<int>>KolayKodKontrol(RafKolayKodKontrolRequest request)
        {
            var Client = await GetClient();
            var response = await Client.GetAsync(apiUrl + $"/api/Raf/KolayKodKontrol?lngDistKod={request.lngDistKod}&txtRafKolayKod={request.txtRafKolayKod}");
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<int>(responseContent));
        }

        private string DepoBilgiQuery(DepoDizilimRequest request)
        {
            string response = "";
            if (request.lngKod == null)
                response += $"?lngDistKod={request.lngDistKod}&lngDepoSira={request.lngDepoSira}";
            else
                response += $"?lngDistKod={request.lngDistKod}&lngDepoSira={request.lngDepoSira}&lngKod={request.lngKod}";
            return response;
        }
    }
}
