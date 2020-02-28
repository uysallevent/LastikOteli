using FluentValidation;
using Lastikoteli.Models.Complex.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Validator.FluentValidation
{
    public class TblsaklamaDetayRequestValidator : AbstractValidator<SaklamaDetayRequest>
    {
        public TblsaklamaDetayRequestValidator()
        {

        }
    }
}
