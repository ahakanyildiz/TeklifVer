using TeklifVer.Dto.CarBrand;

namespace TeklifVer.Dto.CarModel
{
    public class CarModelListDto : IDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public string? ImageName { get; set; }
        public int BrandId { get; set; }
        public CarBrandListDto? Brand { get; set; }
    }
}
