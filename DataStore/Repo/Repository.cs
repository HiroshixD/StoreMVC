using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETStore.Models;
using SVCStore.Interfaces;

namespace DataStore.Repo
{
    public class Repository<T>:IRepository<T>, IDisposable where T:class
    {
        private readonly StoreContext _db;
        public Repository()
        {
            _db = new StoreContext();
        }
        public IQueryable<T> AsQueryable()
        {
            return _db.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public IEnumerable<T> Search(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {
            return _db.Set<T>().Where(predicado);
        }

        public T GetOne(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {
            return _db.Set<T>().Where(predicado).FirstOrDefault();
        }

        public void Add(T model)
        {
            if (_db.Entry<T>(model).State != System.Data.Entity.EntityState.Detached)
                _db.Entry<T>(model).State = System.Data.Entity.EntityState.Added;
            else
                _db.Set<T>().Add(model);
        }

        public void Edit(T model)
        {
            if (_db.Entry<T>(model).State == System.Data.Entity.EntityState.Detached)
                _db.Set<T>().Attach(model);
            _db.Entry<T>(model).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(T model)
        {
            if (_db.Entry<T>(model).State == System.Data.Entity.EntityState.Detached)
                _db.Set<T>().Attach(model);
            _db.Entry<T>(model).State = System.Data.Entity.EntityState.Deleted;
        }

        public T GetItemById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            return;
        }
    }
}
