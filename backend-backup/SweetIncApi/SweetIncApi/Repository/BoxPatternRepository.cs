using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class BoxPatternRepository : BaseRepository<BoxPattern>, IBoxPatternRepository
    {
        public BoxPatternRepository(CandyStoreContext context) : base(context)
        {
            
        }

        public new List<BoxPattern> GetAll()
        {
            return _context.Set<BoxPattern>()
                .Include(x => x.Boxes)
                .AsNoTracking()
                .ToList();

        }

        public new BoxPattern GetByPrimaryKey(int id)
        {
            var boxPattern = _context.Set<BoxPattern>()
                .Include(x => x.Boxes)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return boxPattern;
        }

        public new BoxPattern Update(BoxPattern entity)
        {
            var boxPattern = _context.Set<BoxPattern>()
                .Update(entity).Entity;
            _context.SaveChanges();
            if (boxPattern == null) return null;

            var returnBoxPattern = GetByPrimaryKey(boxPattern.Id);
            return returnBoxPattern;
        }

        public new BoxPattern Add(BoxPattern entity)
        {
            var boxPattern = _context.Set<BoxPattern>()
                .Add(entity).Entity;
            _context.SaveChanges();
            if (boxPattern == null) return null;

            _context.Entry(boxPattern)
                .Collection(x => x.Boxes)
                .Load();
            return boxPattern;
        }
    }
}
