using AutoMapper;
using Entities;
using TeklifVer.Dto.Member;

namespace TeklifVer.Business.Mappings.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberListDto>();
            CreateMap<Member, MemberLoginDto>();
            CreateMap<Member, MemberSignUpDto>();
        }
    }
}
