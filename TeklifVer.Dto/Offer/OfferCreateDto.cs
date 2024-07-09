
namespace TeklifVer.Dto.Offer
{
    public class OfferCreateDto
    {
        public int Price { get; set; }
        public string Message { get; set; }
        public int MemberId { get; set; }
        public int AdvertisingId { get; set; }
    }
}
