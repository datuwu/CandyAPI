using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(CandyStoreContext context) : base(context)
        {
        }

        public new List<Role> GetAll()
        {
            return _context.Set<Role>()
                .Include(x => x.Users)
                .AsNoTracking()
                .ToList();
        }

        public new Role GetByPrimaryKey(int id)
        {
            var role = _context.Set<Role>()
                .Include(x => x.Users)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return role;
        }

        public new Role Update(Role entity)
        {
            var role = _context.Set<Role>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var updateRole = GetByPrimaryKey(role.Id);
            return updateRole;
        }

        public new Role Add(Role entity)
        {
            var box = _context.Set<Role>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(box)
                .Collection(x => x.Users)
                .Load();
            return box;
        }
    }
}
