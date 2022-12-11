//////////////////////////////////////////
// generated AddPersistenceExtension.cs //
//////////////////////////////////////////
using Application.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class AddPersistenceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Name=SqlServerDB"));
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            return services;
        }
    }
}
