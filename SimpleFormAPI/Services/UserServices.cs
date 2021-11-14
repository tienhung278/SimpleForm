using AutoMapper;
using SimpleFormAPI.Contracts;
using SimpleFormAPI.DTOs;
using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleFormAPI.Services
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly EventLogServices _eventLogServices;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository, EventLogServices eventLogServices, IMapper mapper)
        {
            _userRepository = userRepository;
            _eventLogServices = eventLogServices;
            _mapper = mapper;
        }

        public ICollection<UserReadDTO> GetUsers()
        {            
            var users = _userRepository.GetAllUsers();
            var result = _mapper.Map<ICollection<UserReadDTO>>(users);
            return result;
        }

        public UserReadDTO GetUser(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            var userReadDTO = _mapper.Map<UserReadDTO>(user);
            return userReadDTO;
        }

        public Guid CreateUser(UserWriteDTO userWriteDTO)
        {
            var user = _mapper.Map<User>(userWriteDTO);
            user.Id = Guid.NewGuid();
            _userRepository.CreateUser(user);
            _eventLogServices.CreateEventLog<User>(Models.Action.Add, user);
            return user.Id;
        }
        
        public void UpdateUser(Guid id, UserWriteDTO userWriteDTO)
        {
            var updatedUser = _mapper.Map<User>(userWriteDTO);
            updatedUser.Id = id;
            _userRepository.UpdateUser(updatedUser);
            _eventLogServices.CreateEventLog<User>(Models.Action.Update, updatedUser);
        }

        public void DeleteUser(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            _userRepository.DeleteUser(user);
            _eventLogServices.CreateEventLog<User>(Models.Action.Delete, user);
        }

        public bool IsExistingUser(Guid id)
        {
            return _userRepository.GetUserById(id) != null;
        }
    }
}
