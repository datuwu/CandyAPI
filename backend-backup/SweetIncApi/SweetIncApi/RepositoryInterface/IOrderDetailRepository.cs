using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxProduct;
using SweetIncApi.Models.DTO.OrderDetail;
using System.Collections.Generic;

namespace SweetIncApi.RepositoryInterface
{
    public interface IOrderDetailRepository : IBaseRepository<Orderdetail>
    {
        public List<Orderdetail> GetByOrderId(int id);
    }
}
