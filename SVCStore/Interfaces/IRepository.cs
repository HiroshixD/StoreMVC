using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace SVCStore.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(Expression<Func<T, bool>> predicado);
        T GetOne(Expression<Func<T, bool>> predicado);
        void Add(T model);
        void Edit(T model);
        void Delete(T model);
        T GetItemById(int id);
        void Save();
    }
}
