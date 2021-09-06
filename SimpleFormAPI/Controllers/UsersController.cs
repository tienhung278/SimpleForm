using Microsoft.AspNetCore.Mvc;
using SimpleFormAPI.Contracts;
using SimpleFormAPI.DTOs;
using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleFormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UsersController(IUserRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            List<UserReadDTO> userReadDTOs = new List<UserReadDTO>();
            List<User> users = repository.GetAllUser();
            foreach (var user in users)
            {
                UserReadDTO userReadDTO = new UserReadDTO(user);
                userReadDTOs.Add(userReadDTO);
            }
            return Ok(userReadDTOs);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userReadDTO = new UserReadDTO(user);
            return Ok(userReadDTO);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post(UserWriteDTO userWriteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = new User(userWriteDTO);
            repository.AddUser(user);
            return RedirectToAction("Get", new { id = user.Id });
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UserWriteDTO userWriteDTO)
        {
            var user = repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            user.FirstName = userWriteDTO.FirstName;
            user.LastName = userWriteDTO.LastName;
            repository.UpdateUser(user);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var user = repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            repository.DeleteUser(user);
            return NoContent();
        }
    }
}
