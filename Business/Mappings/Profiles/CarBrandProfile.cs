using AutoMapper;
using Entities;
using TeklifVer.Dto.CarBrand;

namespace TeklifVer.Business.Mappings.Profiles
{
    public class CarBrandProfile : Profile
    {
        public CarBrandProfile()
        {
            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<Brand, BrandCreateDto>().ReverseMap();
            CreateMap<Brand, BrandUpdateDto>().ReverseMap();
        }
    }
}
