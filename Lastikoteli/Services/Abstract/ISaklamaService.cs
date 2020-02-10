using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Abstract
{
    public interface ISaklamaService
    {
        Task<ApiResponseGeneric<SaklamaBilgileriResponse>> SaklamaBilgiGetir(SaklamaBilgiRequest request);
    }
}
