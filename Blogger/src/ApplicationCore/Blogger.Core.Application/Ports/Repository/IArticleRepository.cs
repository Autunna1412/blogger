using System;
using System.Collections.Generic;
using System.Text;
using Blogger.Infrastructure.Persistence.Models;

namespace Blogger.Core.Application.Ports.Repository
{
    public interface IArticleRepository : IRepository<Article>
    {
    }
}
