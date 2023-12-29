using Hoteland.Domain.Base;
using Hoteland.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Infrastructure.Repository.Implements
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly HotelandContext _context;
        private DbSet<T> entities;
        public BaseRepository(HotelandContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public IList<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetByID(long ID)
        {
            return entities.SingleOrDefault(x => x.ID == ID);
        }

        public void Insert(T entity)
        {
            _context.Add<T>(entity);
            Save();
        }

        public void Remove(long ID)
        {
            var entity = GetByID(ID);
            entities.Remove(entity);
            Save();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            Save();
        }
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
