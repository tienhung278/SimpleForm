using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Contracts
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();
        User GetUserById(Guid id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
