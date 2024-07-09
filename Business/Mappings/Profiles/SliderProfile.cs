using AutoMapper;
using TeklifVer.Dto.Slider;
using TeklifVer.Entities;

namespace TeklifVer.Business.Mappings.Profiles
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<SliderListDto, Slider>().ReverseMap();
        }
    }
}
