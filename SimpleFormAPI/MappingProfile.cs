using AutoMapper;
using SimpleFormAPI.DTOs;
using SimpleFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserWriteDTO, User>();
        }
    }
}
