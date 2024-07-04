namespace TeklifVer.Dto.Car
{
    public class CarCreateDto : IDto
    {
        public int Year { get; set; }
        public int ModelId { get; set; }
        public string Definition { get; set; }
        public int Price { get; set; }

    }
}
