using SimpleFormAPI.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        public User(UserWriteDTO userWriteDTO)
        {
            Id = Guid.NewGuid();
            FirstName = userWriteDTO.FirstName;
            LastName = userWriteDTO.LastName;
        }
    }
}
