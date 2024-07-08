using Microsoft.AspNetCore.Http;

namespace TeklifVer.Dto.CarBrand
{
    public class BrandUpdateDto : IDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public string? ImgName { get; set; }
        public IFormFile? Image { get; set; }
    }
}
