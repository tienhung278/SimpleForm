using SimpleFormAPI.Contracts;
using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RepositoryContext context;

        public UserRepository(RepositoryContext context)
        {
            this.context = context;
        }
        public void AddUser(User user)
        {
            context.Add(user);
            Save();
        }

        public void DeleteUser(User user)
        {
            context.Delete(user);
            Save();
        }

        public List<User> GetAllUser()
        {
            return context.User;
        }

        public User GetUserById(Guid id)
        {
            return context.User.Find(u => u.Id == id);
        }

        private void Save()
        {
            context.SaveChange();
        }

        public void UpdateUser(User user)
        {
            context.Update(user);
            Save();
        }
    }
}
