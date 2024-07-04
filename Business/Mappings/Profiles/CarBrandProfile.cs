using AutoMapper;
using Entities;
using TeklifVer.Dto.CarBrand;

namespace TeklifVer.Business.Mappings.Profiles
{
    public class CarBrandProfile : Profile
    {
        public CarBrandProfile()
        {
            CreateMap<CarBrand, CarBrandListDto>().ReverseMap();
            CreateMap<CarBrand, CarBrandCreateDto>().ReverseMap();
            CreateMap<CarBrand, CarBrandUpdateDto>().ReverseMap();
        }
    }
}
