using TeklifVer.Entities;

namespace Entities
{
    public class CarBrand : IEntity
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public string? ImgName { get; set; }
        public List<CarModel>? CarModels { get; set; }
    }
}
