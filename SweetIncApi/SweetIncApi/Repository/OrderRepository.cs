using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(CandyStoreContext context) : base(context)
        {
        }

        public new List<Order> GetAll()
        {
            return _context.Set<Order>()
                .Include(x => x.Orderdetails)
                .Include(x => x.User)
                .AsNoTracking()
                .ToList();

        }

        public new Order GetByPrimaryKey(int id)
        {
            var order = _context.Orders
                .Include(x => x.Orderdetails)
                .Include(x => x.User)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return order;

        }

        public new Order Update(Order entity)
        {
            var order = _context.Set<Order>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnOrder = GetByPrimaryKey(order.Id);
            return order;
        }

        public new Order Add(Order entity)
        {
            var order = _context.Set<Order>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(order)
                .Collection(x => x.Orderdetails)
                .Load();
            _context.Entry(order)
                .Reference(x => x.User)
                .Load();
            return order;
        }
    }
}
