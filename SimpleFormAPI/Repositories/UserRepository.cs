using SimpleFormAPI.Contracts;
using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
            
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public ICollection<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(o => o.FirstName)
                .ToList();
        }

        public User GetUserById(Guid id)
        {
            return FindByCondition(u => u.Id == id)
                .SingleOrDefault();
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
