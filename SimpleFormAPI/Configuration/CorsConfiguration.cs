using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Configuration
{
    public static class CorsConfiguration
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            return services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                });
            });
        }
    }
}
