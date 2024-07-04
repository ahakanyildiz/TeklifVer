using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using TeklifVer.Common.Enums;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Member;

namespace Business.Concrete
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<Member> _repository;
        private readonly IMapper _mapper;
        public MemberService(IRepository<Member> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IResult<MemberListDto> AuthenticateUser(string email, string password)
        {
            try
            {
                var result = new Result<MemberListDto>();
                var member = _repository.GetByFilter(x => x.Email == email && x.Password == password);
                return new Result<MemberListDto>(true, _mapper.Map<MemberListDto>(member));
            }
            catch (Exception ex)
            {
                return new Result<MemberListDto>(false, ex.Message);
            }
        }

        public IResult Create(MemberSignUpDto memberSignUpDto)
        {
            try
            {
                memberSignUpDto.RoleId = (int)RoleType.Member;
                _repository.Create(_mapper.Map<Member>(memberSignUpDto));
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult<IEnumerable<Member>> GetAll()
        {
            try
            {
                var data = _repository.GetAll();
                return new Result<IEnumerable<Member>>(true, data);
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<Member>>(false, ex.Message);
            }
        }

        public IResult GetById(int id)
        {
            return new Result();
        }

        public IResult Update(Member member)
        {
            throw new NotImplementedException();
        }


    }
}
