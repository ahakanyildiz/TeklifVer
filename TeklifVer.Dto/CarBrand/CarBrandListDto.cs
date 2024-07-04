namespace TeklifVer.Dto.CarBrand
{
    public class CarBrandListDto : IDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public string? ImgName { get; set; }
    }
}
