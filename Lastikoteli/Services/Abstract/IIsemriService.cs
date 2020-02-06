using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Models.MiyaPortal;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Abstract
{
    public interface IIsemriService
    {
        Task<ApiResponseGeneric<PagingResponse<Randevu>>> IsEmriListesi(IsEmriListeRequest request);
    }
}
