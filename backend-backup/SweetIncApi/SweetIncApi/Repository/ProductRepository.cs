using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly CandyStoreContext _context;

        public ProductRepository(CandyStoreContext context) :base(context)
        {
        }

        public new List<Product> GetAll()
        {
            return _context.Set<Product>()
                .Include(x => x.Brand)
                .Include(x => x.BoxProducts)
                .Include(x => x.Catagory)
                .AsNoTracking()
                .ToList();
        }

        public new Product GetByPrimaryKey(int id)
        {
            var product = _context.Set<Product>()
                .Include(x => x.Brand)
                .Include(x => x.BoxProducts)
                .Include(x => x.Catagory)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return product;

        }

        public new Product Update(Product entity)
        {
            var product = _context.Set<Product>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnProduct = GetByPrimaryKey(product.Id);
            return product;
        }

        public new Product Add(Product entity)
        {
            var product = _context.Set<Product>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(product)
                .Collection(x => x.BoxProducts)
                .Load();
            _context.Entry(product)
                .Reference(x => x.Brand)
                .Load();
            _context.Entry(product)
                .Reference(x => x.Catagory)
                .Load();
            return product;
        }
    }
}
