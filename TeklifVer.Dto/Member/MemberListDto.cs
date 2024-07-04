namespace TeklifVer.Dto.Member
{
    public class MemberListDto : IDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public int RoleId { get; set; }
    }
}
