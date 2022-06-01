using CinemaApp.Common.Dtos;

namespace CinemaApp.Common.Interfaces
{
    public interface IUserService
    {
        string AddUser(UserDto userDto);
        IEnumerable<UserDtoId> GetAllUsers(string userRole);
        IEnumerable<UserDtoId> SearchUsers(string username, string userRole);
        bool DeleteUser(string username);
        void UpdateUser(string username, UserDto userDto);
    }
}
