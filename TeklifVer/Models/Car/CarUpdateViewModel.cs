using TeklifVer.Dto.Car;
using TeklifVer.Dto.CarBrand;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.UI.Models.Car
{
    public class CarUpdateViewModel
    {
        public CarListDto Car { get; set; }
        public List<CarBrandListDto> Brands { get; set; }
        public List<CarModelListDto> Models { get; set; }
    }
}
