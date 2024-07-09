
namespace TeklifVer.Dto.Member
{
    public class MemberUpdateDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
        public string? Salt { get; set; }
        public int RoleId { get; set; }
    }
}
