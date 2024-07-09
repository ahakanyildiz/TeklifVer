using Entities;

namespace TeklifVer.Entities
{
    public class Offer : IEntity
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Message { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int AdvertisingId { get; set; }
        public Advertising Advertising { get; set; }
    }
}
