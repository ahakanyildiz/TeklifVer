using TeklifVer.Entities;

namespace Entities
{
    public class CarModel : IEntity
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public int BrandId { get; set; }
        public CarBrand? Brand { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
