﻿namespace TeklifVer.Dto.Member
{
    public class MemberSignUpDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RoleId { get; set; }
    }
}
