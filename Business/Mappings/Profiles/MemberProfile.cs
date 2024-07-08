using AutoMapper;
using Entities;
using TeklifVer.Dto.Member;

namespace TeklifVer.Business.Mappings.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberListDto>().ReverseMap();
            CreateMap<Member, MemberLoginDto>().ReverseMap();
            CreateMap<Member, MemberSignUpDto>().ReverseMap();
        }
    }
}
