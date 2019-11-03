using Blogger.Core.Application.Queries;
using Blogger.Core.Application.Queries.Interfaces;
using Blogger.Core.Application.Services;
using Blogger.Core.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Core.Application.Extensions
{
    public static class SerivceExtention
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            //Application Services
            services.AddScoped<IArticleApplicationService, ArticleApplicationService>();

            //Query Services
            services.AddScoped<IArticleQueryService, ArticleQueryService>();

            return services;
        }
    }
}
