using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using TeklifVer.Common.Enums;
using TeklifVer.Common.Helpers;
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

        public IResult<MemberListDto> AuthenticateUser(MemberLoginDto dto)
        {
            try
            {
                var data = _repository.GetByFilter(x => x.Email == dto.Email);
                if (data != null)
                {
                    string salt = data.Salt;
                    string hashedPasswordEntered = PasswordHasher.HashPassword(dto.Password, salt);
                    return hashedPasswordEntered == data.PasswordHash ? new Result<MemberListDto>(true,_mapper.Map<MemberListDto>(data))
                           : new Result<MemberListDto>(false,"Eposta ya da şifre yanlış");
                }
                else
                {
                    return new Result<MemberListDto>(false, "Böyle bir kullanıcı bulunamadı");
                }
            }
            catch (Exception ex)
            {
                return new Result<MemberListDto>(false, ex.Message);
            }
        }

        public IResult<Member> GetByEmail(string email)
        {
            var data = _repository.GetByFilter(x => x.Email == email);
            return data!=null ? new Result<Member>(true,data) : new Result<Member>(false,"Kullanıcı bulunamadı");
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

        public IResult<Member> GetById(int id)
        {
            var data = _repository.GetById(id);
            return data != null ? new Result<Member>(true,data) : new Result<Member>(false, "Kullanıcı bulunamadı");
        }

        public IResult Update(Member member)
        {
            throw new NotImplementedException();
        }


    }
}
