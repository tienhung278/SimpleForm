using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleFormAPI.Configuration
{
    public static class ExceptionHandlerConfiguration
    {
        public static IApplicationBuilder ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            return app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.Error(contextFeature.Error, contextFeature.Error.Message);
                        string message = JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "There is an error. Contact Administrator"
                        });
                        await context.Response.WriteAsync(message);
                    }
                });
            });
        }
    }
}
