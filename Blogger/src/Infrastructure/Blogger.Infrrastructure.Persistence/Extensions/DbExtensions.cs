using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blogger.Infrastructure.Persistence.Extensions
{
    public static class DbExtensions
    {
        public static IServiceCollection AddBloggerbContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BloggerContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
