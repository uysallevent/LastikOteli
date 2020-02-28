using FluentValidation;
using Lastikoteli.Helper.Constant;
using Lastikoteli.Models.Complex.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Models.Validator.FluentValidation
{
    public class TblsaklamaDetayRequestValidator : AbstractValidator<SaklamaDetayRequest>, IValidator
    {
        public TblsaklamaDetayRequestValidator()
        {
            RuleFor(x => x.TXTURUNKOD).NotEmpty().WithMessage(Messages.urunNotEmpty);
            RuleFor(x => x.TXTURUNKOD).NotNull().WithMessage(Messages.urunNotEmpty);

            RuleFor(x => x.DBLDISDERINLIGI).NotEmpty().WithMessage(Messages.disDerinligiNotEmpty).Must(DisDerinligiKontrol).WithMessage(Messages.disDerinligiNotEmpty);
            RuleFor(x => x.DBLDISDERINLIGI).NotNull().WithMessage(Messages.disDerinligiNotEmpty).Must(DisDerinligiKontrol).WithMessage(Messages.disDerinligiNotEmpty);

            RuleFor(x => x.TXTDOTHAFTA).NotEmpty().WithMessage(Messages.haftaNotEmpty).Must(HaftaUzunlukKontrol).WithMessage(Messages.haftaNotEmpty);
            RuleFor(x => x.TXTDOTHAFTA).NotNull().WithMessage(Messages.haftaNotEmpty).Must(HaftaUzunlukKontrol).WithMessage(Messages.haftaNotEmpty);
        }

        private bool HaftaUzunlukKontrol(string uzunluk)
        {
            if (string.IsNullOrEmpty(uzunluk) || uzunluk.Length != 4)
                return false;
            else
                return true;
        }

        private bool DisDerinligiKontrol(decimal? disDerinligi)
        {
            if (disDerinligi != null && disDerinligi.Value > 0)
                return true;
            else if (disDerinligi != null && disDerinligi.Value == 0)
                return false;
            else
                return false;
        }
    }
}
