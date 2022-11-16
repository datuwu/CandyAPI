using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class OriginRepository : BaseRepository<Origin>, IOriginRepository
    {
        public OriginRepository(CandyStoreContext context) : base(context)
        {
        }

        public new List<Origin> GetAll()
        {
            return _context.Set<Origin>()
                .Include(x => x.Brands)
                .AsNoTracking()
                .ToList();
        }

        public new Origin GetByPrimaryKey(int id)
        {
            var origin = _context.Origins
                .Include(x => x.Brands)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return origin;
        }

        public new Origin Update(Origin entity)
        {
            var origin = _context.Set<Origin>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var updateOrigin = GetByPrimaryKey(origin.Id);
            return origin;
        }

        public new Origin Add(Origin entity)
        {
            var origin = _context.Set<Origin>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(origin)
                .Collection(x => x.Brands)
                .Load();
            return origin;
        }
    }
}
