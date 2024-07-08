using TeklifVer.Dto.CarBrand;

namespace TeklifVer.UI.Models.CarModel
{
    public class ModelUpdateModel
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public int BrandId { get; set; }
        public IEnumerable<BrandListDto> BrandsList { get; set; }

    }
}
