using Lastikoteli.Helper.ServiceHelper;
using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Models.MiyaPortal;
using Lastikoteli.Services.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Concrete
{
    public class IsEmriService : ServiceManager, IIsemriService
    {
        public async Task<ApiResponseGeneric<PagingResponse<Randevu>>> IsEmriListesi(IsEmriListeRequest request)
        {
            var client = await GetClient();
            var response = await client.PostAsync(APIUrl + "/api/IsEmri/IsEmriListesi", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<PagingResponse<Randevu>>(responseContent));
        }

        public async Task<ApiResponseGeneric<ObservableCollection<IsEmriResponse>>> PlakayaGoreIsEmriListesiGetir(SaklamaPlakaSorgulaRequest request)
        {
            var Client = await GetClient();
            var response = await Client.GetAsync(APIUrl + $"/api/IsEmri/PlakayaGoreIsEmriListesiGetir?lngDistKod={request.lngDistKod}&txtPlaka={request.txtPlaka}");
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<ObservableCollection<IsEmriResponse>>(responseContent));
        }

        public async Task<ApiResponseGeneric<bool>> IsEmriDurumuTamamla(IsEmriDurumGuncelleRequest request)
        {
            var client = await GetClient();
            var response = await client.PostAsync(APIUrl + "/api/IsEmri/IsEmriDurumTamamla", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<bool>(responseContent));
        }
    }
}
