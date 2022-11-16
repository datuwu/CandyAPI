using SweetIncApi.BusinessModels;
using System.Collections.Generic;

namespace SweetIncApi.RepositoryInterface
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T GetByPrimaryKey(params object[] primaryKeys);
        T GetByPrimaryKey(int id);
        T GetByPrimaryKey(int id1, int id2);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void DeleteByPrimaryKey(params object[] primaryKeys);
    }
}
