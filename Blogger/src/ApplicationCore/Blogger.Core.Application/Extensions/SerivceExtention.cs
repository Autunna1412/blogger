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
            services.AddScoped<IArticleApplicationService, ArticleApplicationService>();
       
            return services;
        }
    }
}
