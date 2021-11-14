using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SimpleFormAPI.Contracts;
using SimpleFormAPI.Repositories;
using SimpleFormAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Configuration
{
    public static class UserServicesConfiguration
    {
        public static IServiceCollection ConfigureUserServices(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            return service.AddScoped<UserServices>();
        }
    }
}
