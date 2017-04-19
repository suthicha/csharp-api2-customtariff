using CustomTariff.Api2.DataAccess.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CustomTariff.Api2.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        private AppDbContext _context;

        protected Repository(AppDbContext context)
        {
            this._context = context;
        }

        public virtual int Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            return _context.SaveChanges();
        }

        public virtual List<T> Select()
        {
            return _context.Set<T>().ToList();
        }

        public virtual List<T> Select(string commandText, params object[] paramerts)
        {
            return _context.Database.SqlQuery<T>(commandText, paramerts).ToList();
        }

        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual T Get(int id, string name)
        {
            return _context.Set<T>().Find(id, name);
        }

        public virtual T Get(string commandText, params object[] paramerts)
        {
            return _context.Database.SqlQuery<T>(commandText, paramerts).First();
        }

        public virtual T Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public virtual T Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public T Update(T obj, string commandText, params object[] parameters)
        {
            _context.Database.ExecuteSqlCommand(commandText, parameters);
            _context.SaveChanges();

            return obj;
        }

        public T Insert(T obj, string commandText, params object[] parameters)
        {
            _context.Database.ExecuteSqlCommand(commandText, parameters);
            _context.SaveChanges();
            return obj;
        }

        public int Delete(string commandText, params object[] parameters)
        {
            var result = _context.Database.ExecuteSqlCommand(commandText, parameters);
            _context.SaveChanges();
            return result;
        }
    }
}