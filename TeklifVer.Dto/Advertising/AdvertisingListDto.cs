using TeklifVer.Dto.CarModel;
using TeklifVer.Dto.Member;

namespace TeklifVer.Dto.Car
{
    public class AdvertisingListDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public int Year { get; set; }
        public int ModelId { get; set; }
        public string Description { get; set; }
        public int ViewsCount { get; set; }
        public int Price { get; set; }
        public ModelListDto? Model { get; set; }
        public MemberListDto Member { get; set; }
        public int MemberId { get; set; }
    }
}
