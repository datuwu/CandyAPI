using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.User;
using System.Threading.Tasks;

namespace SweetIncApi.RepositoryInterface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User Register(UserVM userForCreate);
        public Task<string> LoginAsync(UserForLogin userForLogin);
    }
}
