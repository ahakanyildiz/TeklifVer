using TeklifVer.Entities;

namespace Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public string? ImgName { get; set; }
        public List<Model>? Models { get; set; }
    }
}
