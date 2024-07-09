using AutoMapper;
using TeklifVer.Dto.Offer;
using TeklifVer.Entities;

namespace TeklifVer.Business.Mappings.Profiles
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<OfferCreateDto, Offer>().ReverseMap();
        }
    }
}
