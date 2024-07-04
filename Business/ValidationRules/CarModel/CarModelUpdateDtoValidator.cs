using FluentValidation;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.Business.ValidationRules.CarModel
{
    public class CarModelUpdateDtoValidator : AbstractValidator<CarModelUpdateDto>
    {
        public CarModelUpdateDtoValidator()
        {
            RuleFor(x => x.Definition)
               .MinimumLength(1).WithMessage("En az 1 karakter olmak zorunda.")
               .MaximumLength(20).WithMessage("En fazla 20 karakter olmak zorunda")
               .NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Marka seçilmedi.");
        }
    }
}
