using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly CandyStoreContext _context;

        public BaseRepository(CandyStoreContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.Set<T>()
                .Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteByPrimaryKey(params object[] primaryKeys)
        {
            var entity = _context.Set<T>()
                .Find(primaryKeys);

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByPrimaryKey(params object[] primaryKeys)
        {
            return _context.Set<T>()
                .Find(primaryKeys);
        }

        public T GetByPrimaryKey(int id)
        {
            return _context.Set<T>()
                .Find(id);
        }

        public T GetByPrimaryKey(int id1, int id2)
        {
            throw new System.NotImplementedException();
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
