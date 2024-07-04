using Dto.CarModel;
using FluentValidation;

namespace TeklifVer.Business.ValidationRules.CarModel
{
    public class CarModelCreateDtoValidator : AbstractValidator<CarModelCreateDto>
    {
        public CarModelCreateDtoValidator()
        {
            RuleFor(x => x.Definition)
               .MinimumLength(1).WithMessage("En az 1 karakter olmak zorunda.")
               .MaximumLength(20).WithMessage("En fazla 20 karakter olmak zorunda")
               .NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Marka seçilmedi.");

        }
    }
}
