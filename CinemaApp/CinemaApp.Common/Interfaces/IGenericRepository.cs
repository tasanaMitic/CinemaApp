using System.Linq.Expressions;

namespace CinemaApp.Common.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        bool Remove(Guid id);
        bool Remove(int id);
        void Update(Guid id, T entity);
        IEnumerable<T> Find(Expression<Func<T,bool>> expression);
    }
}
