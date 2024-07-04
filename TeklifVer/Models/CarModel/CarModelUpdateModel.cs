using TeklifVer.Dto.CarBrand;

namespace TeklifVer.UI.Models.CarModel
{
    public class CarModelUpdateModel
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public int BrandId { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public IEnumerable<CarBrandListDto> BrandsList { get; set; }

    }
}
