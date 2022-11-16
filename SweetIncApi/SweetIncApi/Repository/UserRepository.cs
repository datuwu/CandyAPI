using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.User;
using SweetIncApi.Models.Responses;
using SweetIncApi.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SweetIncApi.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly CandyStoreContext _context;
        private readonly IMapper _mapper;
        private readonly string authUrl = "http://127.0.0.1:5000/api/auth";
        public UserRepository(CandyStoreContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> LoginAsync(UserForLogin userForLogin)
        {
            User user = _context.Users.Include(u => u.Role).SingleOrDefault(u => u.Email.Equals(userForLogin.Email) && u.Password.Equals(userForLogin.Password));

            if (user == null)
            {
                return null;
            }

            var loginInfo = new UserLoginResponse
            {
                Scope = user.Role.Role1,
                UserInfo = userForLogin,
            };
                        
            var client = new HttpClient();
            client.BaseAddress = new Uri(authUrl);
            client.DefaultRequestHeaders.Add("x-correlationid", user.Id.ToString());

            var response = await client.PostAsJsonAsync("", loginInfo);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            JObject obj = JObject.Parse(jsonResponse);

            return jsonResponse;
        }

        public User Register(UserVM userForCreate)
        {
            User user = _mapper.Map<User>(userForCreate);
            this.Add(user);
            return user;
        }

        public new List<User> GetAll()
        {
            return _context.Set<User>()
                .Include(x => x.Role)
                .Include(x => x.Orders)
                .AsNoTracking()
                .ToList();
        }

        public new User GetByPrimaryKey(int id)
        {
            var user = _context.Set<User>()
                .Include(x => x.Role)
                .Include(x => x.Orders)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return user;
        }

        public new User Update(User entity)
        {
            var user = _context.Set<User>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var updateUser = GetByPrimaryKey(user.Id);
            return updateUser;
        }

        public new User Add(User entity)
        {
            var user = _context.Set<User>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(user)
                .Collection(x => x.Orders)
                .Load();
            _context.Entry(user)
                .Reference(x => x.Role)
                .Load();
            return user;
        }
    }
}
