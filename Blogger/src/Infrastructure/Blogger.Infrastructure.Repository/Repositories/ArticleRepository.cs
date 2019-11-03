using Blogger.Core.Application.Ports.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Blogger.Infrastructure.Persistence;
using Blogger.Core.Domain.Models;

namespace Blogger.Infrastructure.Repository.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly BloggerContext _context;
       
        public ArticleRepository(BloggerContext context) : base(context)
        {
            _context = context;
        }
    }
}
