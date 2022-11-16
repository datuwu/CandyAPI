using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class CatagoryRepository : BaseRepository<Catagory>, ICatagoryRepository
    {
        public CatagoryRepository(CandyStoreContext context) : base(context)
        {
        }

        public new List<Catagory> GetAll()
        {
            return _context.Set<Catagory>()
                .Include(x => x.Products)
                .AsNoTracking()
                .ToList();

        }

        public new Catagory GetByPrimaryKey(int id)
        {
            var catagory = _context.Catagories
                .Include(x => x.Products)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return catagory;
        }

        public new Catagory Update(Catagory entity)
        {
            var catagory = _context.Set<Catagory>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnCatagory = GetByPrimaryKey(catagory.Id);
            return returnCatagory;
        }

        public new Catagory Add(Catagory entity)
        {
            var catagory = _context.Set<Catagory>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(catagory)
                .Collection(x => x.Products)
                .Load();
            return catagory;
        }
    }
}
