using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lastikoteli.Helper.ServiceHelper;
using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Services.Abstract;
using System.Linq;

namespace Lastikoteli.Services.Concrete
{
    public class ParametreService : ServiceManager, IParametreService
    {

        public async Task<ApiResponseGeneric<List<MarkaBilgiResponse>>> MarkaBilgiGetir(MarkaBilgiRequest request)
        {
            var Client = await GetClient();
            var response = await Client.GetAsync(APIUrl + "/api/Parametre/MarkaBilgileriGetir" + MarkaBilgiRequestModelOlustur(request));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<List<MarkaBilgiResponse>>(responseContent));
        }

        private string MarkaBilgiRequestModelOlustur(MarkaBilgiRequest request)
        {
            string response = "?";

            foreach (var item in request.GetType().GetProperties().ToList())
            {
                if (item.Name == "lngUrunTip")
                {
                    response += $"lngruntTip={request.lngUrunTip}&";
                }

                if (item.Name == "txtMarka")
                {
                    response += $"txtMarka={request.txtMarka}&";

                }

                if (item.Name == "txtTaban")
                {
                    response += $"txtTaban={request.txtTaban}&";

                }

                if (item.Name == "txtKesit")
                {
                    response += $"txtKesit={request.txtKesit}&";

                }

                if (item.Name == "txtCap")
                {
                    response += $"txtCap={request.txtCap}&";

                }

                if (item.Name == "txtMevsim")
                {
                    response += $"txtMevsim={request.txtMevsim}&";

                }

                if (item.Name == "txtDesen")
                {
                    response += $"txtDesen={request.txtDesen}";
                }
            }
            return response;
        }
    }
}
