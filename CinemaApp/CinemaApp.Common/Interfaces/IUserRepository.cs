using CinemaApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //TODO
        //IEnumerable<User> GetAllUsers(string userRole);
        //IEnumerable<User> SearchUsers(string username, string userRole);
        IEnumerable<User> Find(string username, string userRole);
    }
}
