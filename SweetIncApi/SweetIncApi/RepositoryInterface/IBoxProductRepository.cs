using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxProduct;
using System.Collections.Generic;

namespace SweetIncApi.RepositoryInterface
{
    public interface IBoxProductRepository : IBaseRepository<BoxProduct>
    {
        public List<BoxProduct> GetByBoxId(int boxId);

        public List<BoxProduct> AddRandomProducts(int boxId);
    }
}
