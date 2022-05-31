using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;
using CinemaApp.Repositories.Context;

namespace CinemaApp.Repositories.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CinemaContext context) : base(context) { }

        public IEnumerable<User> Find(string username, string userRole)
        {
            throw new NotImplementedException();
        }
    }
}
