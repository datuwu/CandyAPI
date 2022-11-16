using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxPattern;
using SweetIncApi.Models.DTO.Order;
using SweetIncApi.Models.DTO.OrderDetail;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class OrderDetailRepository : BaseRepository<Orderdetail>, IOrderDetailRepository
    {
        private readonly CandyStoreContext _context;

        public OrderDetailRepository(CandyStoreContext context) : base(context)
        {
            _context = context;
        }
        public List<Orderdetail> GetByOrderId(int id)
        {
            var orderedItems = _context.Orderdetails
                .Where(e => e.Id == id)
                .Include(e => e.Box)
                .ToList();

            return orderedItems;
        }

        public new List<Orderdetail> GetAll()
        {
            return _context.Set<Orderdetail>()
                .Include(x => x.Box)
                .Include(x => x.IdNavigation)
                .AsNoTracking()
                .ToList();
        }

        public new Orderdetail GetByPrimaryKey(int orderId, int boxId)
        {
            var orderDetail = _context.Orderdetails
                .Include(x => x.IdNavigation)
                .Include(x => x.Box)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == orderId && x.Boxid == boxId);
            return orderDetail;

        }

        public new Orderdetail Update(Orderdetail entity)
        {
            var orderDetail = _context.Set<Orderdetail>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnOrderDetail = GetByPrimaryKey(orderDetail.Id, orderDetail.Boxid);
            return returnOrderDetail;
        }

        public new Orderdetail Add(Orderdetail entity)
        {
            var orderDetail = _context.Set<Orderdetail>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(orderDetail)
                .Reference(x => x.Box)
                .Load();
            _context.Entry(orderDetail)
                .Reference(x => x.IdNavigation)
                .Load();
            return orderDetail;
        }
    }
}
