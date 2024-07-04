using TeklifVer.Dto.CarBrand;

namespace TeklifVer.Dto.CarModel
{
    public class CarModelUpdateDto : IDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public int BrandId { get; set; }
#pragma warning disable CS0234 // The type or namespace name 'CarBrand' does not exist in the namespace 'TeklifVer.Entities' (are you missing an assembly reference?)
        public CarBrandListDto Brand { get; set; }
#pragma warning restore CS0234 // The type or namespace name 'CarBrand' does not exist in the namespace 'TeklifVer.Entities' (are you missing an assembly reference?)
    }
}
