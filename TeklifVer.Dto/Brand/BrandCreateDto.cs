using Microsoft.AspNetCore.Http;

namespace TeklifVer.Dto.CarBrand
{
    public class BrandCreateDto : IDto
    {
        public string? Definition { get; set; }
        public string? ImgName { get; set; }
        public IFormFile Image { get; set; }

    }
}
