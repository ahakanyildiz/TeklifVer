namespace TeklifVer.Dto.Car
{
    public class AdvertisingCreateDto : IDto
    {
        public int Year { get; set; }
        public int ModelId { get; set; }
        public string Description { get; set; }
        public string Definition { get; set; }
        public int Price { get; set; }
        public int MemberId { get; set; }

    }
}
