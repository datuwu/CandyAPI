using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class BoxRepository : BaseRepository<Box>, IBoxRepository
    {

        public BoxRepository(CandyStoreContext context) : base(context)
        {
        }
       
        public new List<Box> GetAll()
        {
            return _context.Set<Box>()
                .Include(x => x.BoxPattern)
                .Include(x => x.Orderdetails)
                .Include(x => x.BoxProducts).ThenInclude(x => x.Product)
                .AsNoTracking()
                .ToList();

        }

        public new Box GetByPrimaryKey(int id)
        {
            var box = _context.Set<Box>()
                .Include(x => x.BoxPattern)
                .Include(x => x.Orderdetails)
                .Include(x => x.BoxProducts)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Brand)
                .ThenInclude(x => x.Origin)

                .Include(x => x.BoxPattern)
                .Include(x => x.Orderdetails)
                .Include(x => x.BoxProducts)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Catagory)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return box;

        }

        public new Box Update(Box entity)
        {
            var box = _context.Set<Box>()
                .Update(entity).Entity;
            _context.SaveChanges();
            if (box == null) return null;

            var newBox = GetByPrimaryKey(box.Id);
            return newBox;
        }

        public new Box Add(Box entity)
        {
            var box = _context.Set<Box>()
                .Add(entity).Entity;
            _context.SaveChanges();
            if (box == null) return null;

            _context.Entry(box)
                .Reference(x => x.BoxPattern)
                .Load();
            return box;
        }
    }
}
