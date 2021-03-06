﻿using FluentValidation;
using Lastikoteli.Helper.Constant;
using Lastikoteli.Models.Complex.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Validator.FluentValidation
{
    public class SaklamaBaslikRequestValidator : AbstractValidator<SaklamaBaslikRequest>, IValidator
    {
        public SaklamaBaslikRequestValidator()
        {
            RuleFor(x => x.TXTPLAKA).NotEmpty().WithMessage(Messages.plakaNotEmtpy);
            RuleFor(x => x.TXTPLAKA).NotNull().WithMessage(Messages.plakaNotEmtpy);

            RuleFor(x => x.LNGARACKM).NotEmpty().WithMessage(Messages.kmNotEmpty);
            RuleFor(x => x.LNGARACKM).NotNull().WithMessage(Messages.kmNotEmpty);
            RuleFor(x => x.LNGARACKM).Must(KmKontrol).WithMessage(Messages.kmNotEmpty);

            RuleFor(x => x.TXTMUSTERIUNVAN).NotEmpty().WithMessage(Messages.unvanNotEmpty);
            RuleFor(x => x.TXTMUSTERIUNVAN).NotNull().WithMessage(Messages.unvanNotEmpty);

            RuleFor(x => x.TXTCEPTEL).NotEmpty().When(x => x.TXTEMAIL == null).WithMessage(Messages.cepTelNotEmtpy);
            RuleFor(x => x.TXTCEPTEL).NotNull().When(x => x.TXTEMAIL == null).WithMessage(Messages.cepTelNotEmtpy);
            RuleFor(x => x.TXTCEPTEL).Matches("^(5(\\d{9}))$").WithMessage(Messages.cepTelFormatNotValid);

            RuleFor(x => x.TXTEMAIL).NotEmpty().When(x => x.TXTCEPTEL == null).WithMessage(Messages.emailNotEmtpy);
            RuleFor(x => x.TXTEMAIL).NotNull().When(x => x.TXTCEPTEL == null).WithMessage(Messages.emailNotEmtpy);
            RuleFor(x => x.TXTEMAIL).Matches("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$").WithMessage(Messages.emailFormatNotValid);

            RuleFor(x => x.TXTTCKIMLIKNO).NotEmpty().When(x => string.IsNullOrEmpty(x.TXTVN)).WithMessage(Messages.tcNoNotEmpty);
            RuleFor(x => x.TXTTCKIMLIKNO).NotNull().When(x => string.IsNullOrEmpty(x.TXTVN)).WithMessage(Messages.tcNoNotEmpty);

            RuleFor(x => x.TXTVN).NotEmpty().When(x => string.IsNullOrEmpty(x.TXTTCKIMLIKNO)).WithMessage(Messages.vNoNotEmpty);
            RuleFor(x => x.TXTVN).NotNull().When(x => string.IsNullOrEmpty(x.TXTTCKIMLIKNO)).WithMessage(Messages.vNoNotEmpty);

            RuleForEach(x => x.Tblsaklamadetay).SetValidator(new TblsaklamaDetayRequestValidator()).When(x => x.LNGADET == null || x.LNGADET == 0);
        }

        private bool KmKontrol(long km)
        {
            if (km > 0)
                return true;
            else
                return false;
        }
    }
}
