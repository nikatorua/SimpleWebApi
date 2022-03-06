using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WebApiTest6._0.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}