using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxProduct;
using SweetIncApi.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class BoxProductRepository : BaseRepository<BoxProduct>, IBoxProductRepository
    {
        private readonly CandyStoreContext _context;
        public BoxProductRepository(CandyStoreContext context) : base(context)
        {
            _context = context;
        }
        public List<BoxProduct> GetByBoxId(int boxId)
        {
            var boxItems = _context.BoxProducts
                .Where(e => e.BoxId == boxId)
                .Include(x => x.Product)
                .AsNoTracking()
                .ToList();

            return boxItems;
        }

        public List<BoxProduct> AddRandomProducts(int boxId)
        {
            //Get total price of pattern
            var box = _context.Boxes
                .Include(x => x.BoxPattern)
                .Include(x => x.BoxProducts)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == boxId);

            var boxPatternPrice = box.BoxPattern.Price;

            //Get total price of box product
            var boxPrice = box.BoxProducts.Sum(x => x.Product.Price * x.Quantity);

            //Random add 
            var productList = _context.Products
                .Where(x => x.Quantity > 0)
                .ToList();
            var userProducts = _context.BoxProducts
                .Where(x => x.BoxId == boxId)
                .Select(x => x.Product)
                .ToList();
            var random = new Random();
            while (boxPrice < boxPatternPrice)
            {
                var randomProducts = random.Next(productList.Count());
                var existedStoredProduct = productList[randomProducts];
                var existedUserProduct = _context.BoxProducts
                        .FirstOrDefault(x => x.ProductId == existedStoredProduct.Id && x.BoxId == boxId);

                if (existedUserProduct == null)
                {
                    _context.BoxProducts.Add(new BoxProduct
                    {
                        BoxId = boxId,
                        ProductId = existedStoredProduct.Id,
                        Quantity = 0
                    });
                    _context.SaveChanges();

                    existedUserProduct = _context.BoxProducts
                        .FirstOrDefault(x => x.ProductId == existedStoredProduct.Id && x.BoxId == boxId);
                }

                var productEnough = existedUserProduct.Quantity < existedStoredProduct.Quantity;
                if (productEnough)
                {
                    existedUserProduct.Quantity += 1;
                    _context.BoxProducts.Update(existedUserProduct);
                    _context.SaveChanges();
                }

                boxPrice = box.BoxProducts.Sum(x => x.Product.Price * x.Quantity);
                boxPatternPrice = box.BoxPattern.Price;
            }

            
            return GetByBoxId(boxId);
        }

        public new List<BoxProduct> GetAll()
        {
            var boxProductList = _context.Set<BoxProduct>()
                .Include(x => x.Box)
                .Include(x => x.Product)
                .AsNoTracking()
                .ToList();
            return boxProductList;
        }

        public new BoxProduct GetByPrimaryKey(int boxId, int productId)
        {    
            var boxPattern = _context.Set<BoxProduct>()
                .Include(x => x.Box)
                .ThenInclude(x => x.BoxPattern)
                .Include(x => x.Product)
                .ThenInclude(x => x.Brand)
                .ThenInclude(x => x.Origin)
                .Include(x => x.Product)
                .ThenInclude(x => x.Catagory)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.BoxId == boxId && x.ProductId == productId);
            return boxPattern;

        }

        public new BoxProduct Update(BoxProduct entity)
        {
            var boxProduct = _context.Set<BoxProduct>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnBoxProduct = GetByPrimaryKey(boxProduct.BoxId, boxProduct.ProductId);
            return returnBoxProduct;
        }

        public new BoxProduct Add(BoxProduct entity)
        {
            var boxProduct = _context.Set<BoxProduct>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(boxProduct)
                .Reference(x => x.Box)
                .Load();
            _context.Entry(boxProduct)
                .Reference(x => x.Product)
                .Load();
            return boxProduct;
        }
    }
}
