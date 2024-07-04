using TeklifVer.Dto.CarBrand;

namespace TeklifVer.UI.Models.CarModel
{
    public class CarModelUpdateModel
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public string? BrandName { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Image' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public IFormFile Image { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Image' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string? ImageName { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'BrandsList' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public IEnumerable<CarBrandListDto> BrandsList { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'BrandsList' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
