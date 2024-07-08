namespace TeklifVer.UI.Models.CarBrand
{
    public class BrandCreateModel
    {
        public string? Definition { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Image' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public IFormFile Image { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Image' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
