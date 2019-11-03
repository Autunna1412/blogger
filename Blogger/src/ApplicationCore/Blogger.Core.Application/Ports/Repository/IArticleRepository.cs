using Blogger.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Core.Application.Ports.Repository
{
    public interface IArticleRepository : IRepository<Article>
    {
    }
}
