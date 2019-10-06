using Blogger.Core.Application.Ports.Repository;
using Microsoft.Extensions.DependencyInjection;
using Blogger.Infrastructure.Repository.UnitOfWork;

namespace Blogger.Infrastructure.Repository.Extensions
{
    public static class UnitOfWorkExtension
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorks>();
            return services;
        }
    }
}
