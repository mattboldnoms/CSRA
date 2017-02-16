using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();

        T FindByID(object id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(object id);

        void Save();

        IEnumerable<T> GetForPager(IEnumerable<T> collection, int page, int pageSize);
    }
}
