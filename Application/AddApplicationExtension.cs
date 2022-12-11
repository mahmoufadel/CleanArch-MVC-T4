//////////////////////////////////////////
// generated AddApplicationExtension.cs //
//////////////////////////////////////////
using Application.ServiceInterfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class AddApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            return services;
        }
    }
}
