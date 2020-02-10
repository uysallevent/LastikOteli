using Lastikoteli.Helper.ServiceHelper;
using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Concrete
{
    public class SaklamaService : ServiceManager, ISaklamaService
    {
        public async Task<ApiResponseGeneric<SaklamaBilgileriResponse>> SaklamaBilgiGetir(SaklamaBilgiRequest request)
        {
            var Client = await GetClient();
            var response = await Client.GetStringAsync(APIUrl + $"/api/Saklama/SaklamaKayitGetir?lngDistKod={request.lngDistKod}&lngSaklamaBaslik={request.lngSaklamaBaslik}");
            return await Task.FromResult(ApiResultCheck.ResultCheck<SaklamaBilgileriResponse>(response));
        }
    }
}
