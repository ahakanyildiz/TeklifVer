using TeklifVer.Dto.CarBrand;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.Dto.Car
{
    public class CarListDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public int Year { get; set; }
        public int ModelId { get; set; }
        public int Price { get; set; }
        public CarModelListDto? Model { get; set; }
        public CarBrandListDto? Brand { get; set; }
    }
}
