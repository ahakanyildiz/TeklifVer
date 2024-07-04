using TeklifVer.Dto.CarModel;

namespace TeklifVer.UI.Models.Car
{
    public class CarListModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int ModelId { get; set; }
        public CarModelListDto? Model { get; set; }
    }
}
