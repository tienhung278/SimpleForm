using AutoMapper;
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
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UsersController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _repository.User.GetAllUsers();
            var result = _mapper.Map<ICollection<UserReadDTO>>(users);
            return Ok(result);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _repository.User.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<UserReadDTO>(user);
            return Ok(result);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post(UserWriteDTO userWriteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = _mapper.Map<User>(userWriteDTO);
            user.Id = Guid.NewGuid();
            _repository.User.CreateUser(user);
            _repository.Save();
            return RedirectToAction("Get", new { id = user.Id });
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UserWriteDTO userWriteDTO)
        {
            var user = _repository.User.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var updatedUser = _mapper.Map<User>(userWriteDTO);
            updatedUser.Id = id;
            _repository.User.UpdateUser(updatedUser);
            _repository.Save();
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var user = _repository.User.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _repository.User.DeleteUser(user);
            _repository.Save();
            return NoContent();
        }
    }
}
