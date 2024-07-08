using TeklifVer.Entities;

namespace Entities
{
    public class Model : IEntity
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public List<Advertising>? Advertisings { get; set; }
    }
}
