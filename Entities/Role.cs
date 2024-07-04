using Entities;

namespace TeklifVer.Entities
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public ICollection<Member> Members { get; set; }

    }
}
