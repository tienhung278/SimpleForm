using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Contracts
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserById(Guid id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
