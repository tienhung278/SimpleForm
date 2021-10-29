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
        Object _store;
        string _filename;

        public RepositoryContext()
        {
            
        }

        public List<T> Set<T>() where T : class
        {
            _filename = string.Format("{0}Store.txt", typeof(T).Name);
            if (File.Exists(_filename))
            {
                var json = File.ReadAllText(_filename);
                _store = JsonSerializer.Deserialize<List<T>>(json);
            }
            else
            {
                _store = new List<T>();
            }

            return _store as List<T>;
        }

        public void SaveChanges()
        {
            var json = JsonSerializer.Serialize(_store);
            File.WriteAllText(_filename, json);
        }
    }
}
