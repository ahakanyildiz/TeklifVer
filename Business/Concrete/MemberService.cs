using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using TeklifVer.Common.Enums;
using TeklifVer.Common.Helpers;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Member;
using TeklifVer.Entities;

namespace Business.Concrete
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<Member> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<Role> _roleRepository;
        public MemberService(IRepository<Member> repository, IMapper mapper, IRepository<Role> roleRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }


        public void CreateUserAndRoles()
        {

            var role1 = new Role()
            {
                Definition = "Member"
            };

            var role2 = new Role()
            {
                Definition = "Admin"
            };

            _roleRepository.Create(role1);
            _roleRepository.Create(role2);

            var salt = PasswordHasher.GenerateSalt();
            var member1 = new Member()
            {
                Email = "teknomanihah@gmail.com",
                Name = "Hakan",
                Surname = "Yıldız",
                Salt = salt,
                PasswordHash = PasswordHasher.HashPassword("123", salt),
                PhoneNumber = "5060407176",
                RoleId = (int)RoleType.Admin
            };

            _repository.Create(member1);

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
                    return hashedPasswordEntered == data.PasswordHash ? new Result<MemberListDto>(true, _mapper.Map<MemberListDto>(data))
                           : new Result<MemberListDto>(false, "Eposta ya da şifre yanlış");
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
            return data != null ? new Result<Member>(true, data) : new Result<Member>(false, "Kullanıcı bulunamadı");
        }

        public IResult Create(MemberSignUpDto memberSignUpDto)
        {
            try
            {
                memberSignUpDto.RoleId = (int)RoleType.Member;
                memberSignUpDto.Salt = PasswordHasher.GenerateSalt();
                memberSignUpDto.PasswordHash = PasswordHasher.HashPassword(memberSignUpDto.PasswordHash, memberSignUpDto.Salt);
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

        public IResult<MemberListDto> GetById(int id)
        {
            var data = _repository.GetById(id);
            return data != null ? new Result<MemberListDto>(true, _mapper.Map<MemberListDto>(data)) : new Result<MemberListDto>(false, "Kullanıcı bulunamadı");
        }

        public IResult Update(MemberUpdateDto dto)
        {
            try
            {
                var member = _repository.GetById(dto.Id);
                dto.RoleId = member.RoleId;
                dto.PasswordHash = member.PasswordHash;
                dto.Salt = member.Salt;
                _repository.UpdateEntryState(member, _mapper.Map<Member>(dto));
                return new Result(true);

            }
            catch (Exception ex)
            {

                return new Result(false, ex.Message);
            }

        }

    }
}
