using CinemaApp.Models.Models;

namespace CinemaApp.Common.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //TODO
        //IEnumerable<User> GetAllUsers(string userRole);
        //IEnumerable<User> SearchUsers(string username, string userRole);
        IEnumerable<User> Find(string username, string userRole);
        bool RemoveByUserName(string username);
        void UpdateUser(User user);
    }
}
