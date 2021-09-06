using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleFormAPI.Repositories
{
    public class RepositoryContext
    {
        private List<User> store;

        public List<User> User
        {
            get
            {
                return store;
            }
        }

        public RepositoryContext()
        {
            store = new List<User>();
        }

        public void Add(User user)
        {
            store.Add(user);
        }

        public void Update(User user)
        {
            var u = store.Find(u => u.Id == user.Id);
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
        }

        public void Delete(User user)
        {
            store.Remove(user);
        }

        public void SaveChange()
        {
            string json = JsonSerializer.Serialize(store);
            File.WriteAllText("data.txt", json);
        }
    }
}
