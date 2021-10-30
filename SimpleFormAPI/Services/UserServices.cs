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
        private readonly IEventLogRepository _eventLogRepository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository, IEventLogRepository eventLogRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _eventLogRepository = eventLogRepository;
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
            CreateEventLog(Models.Action.Add, user);
            return user.Id;
        }
        
        public void UpdateUser(Guid id, UserWriteDTO userWriteDTO)
        {
            var updatedUser = _mapper.Map<User>(userWriteDTO);
            updatedUser.Id = id;
            _userRepository.UpdateUser(updatedUser);
            CreateEventLog(Models.Action.Update, updatedUser);
        }

        public void DeleteUser(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            _userRepository.DeleteUser(user);
            CreateEventLog(Models.Action.Delete, user);
        }

        public bool IsExistingUser(Guid id)
        {
            return _userRepository.GetUserById(id) != null;
        }

        private void CreateEventLog(Models.Action action, User user)
        {
            _eventLogRepository.CreateEventLog(new EventLog
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Event = action,
                Information = JsonSerializer.Serialize(user),
                TransactionId = Guid.NewGuid()
            });
        }
    }
}
