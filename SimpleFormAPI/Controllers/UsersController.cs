using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleFormAPI.Contracts;
using SimpleFormAPI.DTOs;
using SimpleFormAPI.Models;
using SimpleFormAPI.Services;
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
        private readonly UserServices _userServices;

        public UsersController(UserServices userServices)
        {
            _userServices = userServices;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userServices.GetUsers());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (!_userServices.IsExistingUser(id))
            {
                return NotFound();
            }
            return Ok(_userServices.GetUser(id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post(UserWriteDTO userWriteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = _userServices.CreateUser(userWriteDTO);
            return RedirectToAction("Get", new { id = userId });
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UserWriteDTO userWriteDTO)
        {
            if (!_userServices.IsExistingUser(id))
            {
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _userServices.UpdateUser(id, userWriteDTO);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_userServices.IsExistingUser(id))
            {
                return NotFound();
            }
            _userServices.DeleteUser(id);
            return NoContent();
        }
    }
}
