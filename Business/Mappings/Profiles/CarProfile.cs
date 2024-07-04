using AutoMapper;
using Entities;
using TeklifVer.Dto.Car;

namespace TeklifVer.Business.Mappings.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            //CreateMap<Car, CarListDto>()
            //      .ForMember(dest => dest.Model, opt => opt.MapFrom(src => new CarModelListDto
            //      {
            //          Id = src.Model.Id,
            //          Definition = src.Model.Definition,
            //          BrandId = src.Model.BrandId
            //      }))
            //      .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => new CarBrandListDto
            //      {
            //          Id = src.Model.Brand.Id,
            //          Definition = src.Model.Brand.Definition,
            //          ImgName = src.Model.Brand.ImgName
            //      })).ReverseMap();
            CreateMap<Car, CarListDto>().ReverseMap();
            CreateMap<CarCreateDto, Car>().ReverseMap();
            CreateMap<CarUpdateDto, Car>().ReverseMap();
        }
    }
}
