using AutoMapper;
using Dto.CarModel;
using Entities;
using TeklifVer.Dto.CarBrand;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.Business.Mappings.Profiles
{
    public class CarModelProfile : Profile
    {
        public CarModelProfile()
        {
            CreateMap<Model, ModelListDto>()
             .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand != null ? new BrandListDto
             {
                 Id = src.Brand.Id,
                 Definition = src.Brand.Definition,
                 ImgName = src.Brand.ImgName
             } : null));
            CreateMap<Model, ModelCreateDto>().ReverseMap();
            CreateMap<Model, ModelUpdateDto>().ReverseMap();

        }
    }
}
