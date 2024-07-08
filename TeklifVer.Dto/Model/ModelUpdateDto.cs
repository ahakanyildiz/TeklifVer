using TeklifVer.Dto.CarBrand;

namespace TeklifVer.Dto.CarModel
{
    public class ModelUpdateDto : IDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public int BrandId { get; set; }
        public BrandListDto Brand { get; set; }
    }
}
