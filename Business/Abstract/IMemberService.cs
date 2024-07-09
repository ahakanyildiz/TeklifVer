using Entities;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Member;

namespace Business.Abstract
{
    public interface IMemberService
    {
        public IResult Create(MemberSignUpDto memberSignUpDto);
        public IResult Update(MemberUpdateDto dto);
        public IResult Delete(int id);
        public IResult<IEnumerable<Member>> GetAll();
        public IResult<MemberListDto> GetById(int id);
        public IResult<MemberListDto> AuthenticateUser(MemberLoginDto dto);
        public void CreateUserAndRoles();
    }
}
