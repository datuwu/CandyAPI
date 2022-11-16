using SweetIncApi.Models.DTO.User;

namespace SweetIncApi.Models.Responses
{
    public class UserLoginResponse
    {
        public string Scope { get; set; }
        public UserForLogin UserInfo { get; set; }

    }
}
