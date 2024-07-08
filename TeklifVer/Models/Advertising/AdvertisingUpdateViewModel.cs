using TeklifVer.Dto.Car;
using TeklifVer.Dto.CarBrand;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.UI.Models.Car
{
    public class AdvertisingUpdateViewModel
    {
        public AdvertisingListDto Car { get; set; }
        public List<BrandListDto> Brands { get; set; }
        public List<ModelListDto> Models { get; set; }
    }
}
