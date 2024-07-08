using TeklifVer.Dto.CarModel;

namespace TeklifVer.UI.Models.Car
{
    public class AdvertisingListModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int ModelId { get; set; }
        public ModelListDto? Model { get; set; }
    }
}
