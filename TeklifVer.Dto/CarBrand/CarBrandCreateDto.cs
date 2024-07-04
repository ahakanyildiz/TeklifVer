using Microsoft.AspNetCore.Http;

namespace TeklifVer.Dto.CarBrand
{
    public class CarBrandCreateDto : IDto
    {
        public string? Definition { get; set; }
        public string? ImgName { get; set; }
        public IFormFile Image { get; set; }

    }
}
