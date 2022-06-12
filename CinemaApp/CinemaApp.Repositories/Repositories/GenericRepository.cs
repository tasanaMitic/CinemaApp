 using CinemaApp.Common.Interfaces;
using CinemaApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace CinemaApp.Repositories.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CinemaContext _context;
        public GenericRepository(CinemaContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DuplicateNameException();
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public bool Remove(Guid id)
        {
            try
            {
                var entity = _context.Set<T>().Find(id);
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                var entity = _context.Set<T>().Find(id);
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Update(Guid id, T entity)
        {
            try
            {
                //TODO provera sa id
                _context.Set<T>().Update(entity);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new KeyNotFoundException();
            }
            catch (DbUpdateException e)
            {
                throw new DuplicateNameException();
            }
        }
    }
}
