using TeklifVer.Dto;

namespace Dto.CarModel
{
    public class ModelCreateDto : IDto
    {
        public string? Definition { get; set; }
        public int BrandId { get; set; }
    }
}
