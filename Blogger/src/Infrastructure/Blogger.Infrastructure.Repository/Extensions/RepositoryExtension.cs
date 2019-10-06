using Blogger.Core.Application.Ports.Repository;
using Blogger.Infrastructure.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Infrastructure.Repository.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();

            return services;
        }
    }
}
