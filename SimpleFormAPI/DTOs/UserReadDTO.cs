using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.DTOs
{
    public class UserReadDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserReadDTO(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}
