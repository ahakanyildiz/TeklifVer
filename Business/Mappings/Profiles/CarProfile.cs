using AutoMapper;
using Entities;
using TeklifVer.Dto.Car;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.Business.Mappings.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Advertising, AdvertisingListDto>().ReverseMap();
                  //.ForMember(dest => dest.Model, opt => opt.MapFrom(src => new CarModelListDto
                  //{
                  //    Id = src.CarModel.Id,
                  //    Definition = src.CarModel.Definition,
                  //    BrandId = src.CarModel.BrandId
                  //})).ReverseMap();

            //CreateMap<Car, CarListDto>().ReverseMap();
            CreateMap<AdvertisingCreateDto, Advertising>().ReverseMap();
            CreateMap<AdvertisingUpdateDto, Advertising>().ReverseMap();
            CreateMap<AdvertisingUpdateDto, AdvertisingListDto>().ReverseMap();
        }
    }
}
