using Microsoft.Extensions.DependencyInjection;
using SimpleFormAPI.Contracts;
using SimpleFormAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFormAPI.Configuration
{
    public static class RepoContextConfiguration
    {
        public static IServiceCollection ConfigureRepoContext(this IServiceCollection services)
        {
            return services.AddScoped<IRepositoryWrapper, RepositoryWrapper>(provider =>
            {
                var repositoryContext = new RepositoryContext();
                return new RepositoryWrapper(repositoryContext);
            });
        }
    }
}
