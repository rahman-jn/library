using Entities;
using libraryapi.Interfaces;
using libraryapi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

        }
    }
    
}