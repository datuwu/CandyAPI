namespace SweetIncApi.Models.DTO.User
{
    public class UpdateUserVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int? Roleid { get; set; }
        public bool? Status { get; set; }
    }
}
