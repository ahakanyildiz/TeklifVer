namespace TeklifVer.Dto.Car
{
    public class AdvertisingUpdateDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }
        public int ViewsCount { get; set; }
        public int ModelId { get; set; }
        public int Price { get; set; }
        public int MemberId { get; set; }
    }
}
