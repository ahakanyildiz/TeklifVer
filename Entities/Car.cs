using TeklifVer.Entities;

namespace Entities
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public int Year { get; set; }
        public int ModelId { get; set; }
        public CarModel? CarModel { get; set; }
        public int Price { get; set; }


    }
}
