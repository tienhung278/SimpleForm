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
            service.AddScoped<IUserRepository>(provider =>
            {
                return new UserRepository(provider.GetRequiredService<RepositoryContext>());
            });

            service.AddScoped<IEventLogRepository>(provider =>
            {
                return new EventLogRepository(provider.GetRequiredService<RepositoryContext>());
            });

            return service.AddScoped<UserServices>(provider =>
            {
                var userRepository = provider.GetRequiredService<IUserRepository>();
                var eventLogRepository = provider.GetRequiredService<IEventLogRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                return new UserServices(userRepository, eventLogRepository, mapper);
            });
        }
    }
}
