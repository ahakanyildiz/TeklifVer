using TeklifVer.Dto;

namespace Dto.CarModel
{
    public class CarModelCreateDto : IDto
    {
        public string? Definition { get; set; }
        public int BrandId { get; set; }
    }
}
