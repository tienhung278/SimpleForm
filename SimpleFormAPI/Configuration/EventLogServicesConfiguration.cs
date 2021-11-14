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
    public static class EventLogServicesConfiguration
    {
        public static IServiceCollection ConfigureEventLogServices(this IServiceCollection service)
        {
            service.AddScoped<IEventLogRepository, EventLogRepository>();
            return service.AddScoped<EventLogServices>();
        }
    }
}
