using FluentValidation;
using TeklifVer.Dto.CarBrand;

namespace TeklifVer.Business.ValidationRules.CarBrand
{
    public class CarBrandCreateDtoValidator : AbstractValidator<BrandCreateDto>
    {
        public CarBrandCreateDtoValidator()
        {
            RuleFor(x => x.Definition).MinimumLength(1).WithMessage("En az 1 karakter olmak zorunda.")
                .MaximumLength(20).WithMessage("En fazla 20 karakter olmak zorunda");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim yüklemediniz.");
            RuleFor(x => x.ImgName).NotEmpty().WithMessage("Resim yüklemediniz.");
        }
    }
}
