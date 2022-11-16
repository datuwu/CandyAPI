using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(CandyStoreContext context) : base(context)
        {
        }

        public new List<Brand> GetAll()
        {
            return _context.Set<Brand>()
                .Include(x => x.Products)
                .Include(x => x.Origin)
                .AsNoTracking()
                .ToList();
        }

        public new Brand GetByPrimaryKey(int id)
        {
            var brand = _context.Set<Brand>()
                .Include(x => x.Products)
                .Include(x => x.Origin)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return brand;

        }

        public new Brand Update(Brand entity)
        {
            var brand = _context.Set<Brand>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnBrand = GetByPrimaryKey(brand.Id);
            return returnBrand;
        }

        public new Brand Add(Brand entity)
        {
            var brand = _context.Set<Brand>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(brand)
                .Collection(x => x.Products)
                .Load();
            _context.Entry(brand)
                .Reference(x => x.Origin)
                .Load();
            return brand;
        }
    }
}
