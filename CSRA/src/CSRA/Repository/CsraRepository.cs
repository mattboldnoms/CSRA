using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRA.Data;
using Microsoft.EntityFrameworkCore;

namespace CSRA.Repository
{
    public class CsraRepository<T> : IRepository.IGenericRepository<T> where T : class
    {
        protected CsraContext db;
        protected DbSet<T> entities;

        public CsraRepository(CsraContext dbContext)
        {
            this.db = dbContext;
            entities = db.Set<T>();
        }

        public IQueryable<T> All()
        {
            return entities;
        }

        public T FindByID(object id)
        {
            throw new NotImplementedException();
            //return entities.Find(id);
        }

        public void Insert(T obj)
        {
            entities.Add(obj);
        }

        public void Update(T obj)
        {
            entities.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
            //T existing = entities.Find(id);
            //entities.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<T> GetForPager(IEnumerable<T> collection, int page, int pageSize)
        {
            return collection.Skip(pageSize * (page - 1)).Take(pageSize);
        }
    }
}
