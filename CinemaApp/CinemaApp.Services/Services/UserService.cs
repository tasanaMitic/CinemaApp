using CinemaApp.Common.Dtos;
using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string AddUser(UserDto userDto)
        {
            _unitOfWork.UserRepository.Add(new User { Username = userDto.Username, 
                                                        Name = userDto.Name,
                                                        Password = userDto.Password,
                                                        Email = userDto.Email,
                                                        Role = userDto.Role});
            return userDto.Username;
        }

        public bool DeleteUser(string username)
        {
            return _unitOfWork.UserRepository.RemoveByUserName(username);
        }

        public IEnumerable<UserDtoId> GetAllUsers(string userRole)//TODO userrole?
        {
            return MapUserListToUserDtoIdList(_unitOfWork.UserRepository.GetAll());
        }

        public IEnumerable<UserDtoId> SearchUsers(string username, string userRole)
        {
            return MapUserListToUserDtoIdList(_unitOfWork.UserRepository.Find(username, userRole));
        }

        public void UpdateUser(string username, UserDto userDto)
        {
            _unitOfWork.UserRepository.UpdateUser(new User { Username = userDto.Username,
                                                            Name = userDto.Name,
                                                            Password = userDto.Password,
                                                            Email = userDto.Email,
                                                            Role = userDto.Role });
        }

        private IEnumerable<UserDtoId> MapUserListToUserDtoIdList(IEnumerable<User> users)
        {
            return users.Select(x => new UserDtoId() { Name = x.Name, Username = x.Username, Password = x.Password, Email = x.Email, Role = x.Role.ToString()});
        }
    }
}
