namespace SweetIncApi.Models.DTO.User
{
    public class UserVM
    {
        private static readonly int CustomerRoleId = 3;
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int? Roleid { get; set; } = CustomerRoleId;
        public bool? Status { get; set; } = true;
    }
}
