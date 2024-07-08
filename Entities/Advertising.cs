using TeklifVer.Entities;

namespace Entities
{
    public class Advertising : IEntity
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        //2şer 2şer artıyor bi bak.
        public int ViewsCount { get; set; } = 0;
        public int Year { get; set; }
        public int ModelId { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public Model? Model { get; set; }
        public int Price { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
