using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blogger.Core.Application.Dtos;
using Blogger.Core.Application.Ports.Repository;
using Blogger.Core.Application.Queries.Interfaces;
using Blogger.Core.Domain.Models;
using Blogger.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Core.Application.Queries
{
    public class ArticleQueryService : IArticleQueryService
    {
        private readonly BloggerContext _bloggerDbContext;
        private readonly IMapper _mapper;

        public ArticleQueryService(
            BloggerContext bloggerContext, 
            IMapper mapper,
            IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _bloggerDbContext = bloggerContext;
        }   
        public async Task<List<ArticleDto>> GetList()
        {
            var articlesInDb = await _bloggerDbContext.Articles
               .Select(a => _mapper.Map<Article, ArticleDto>(a)).ToListAsync();

            return articlesInDb;
        }
    }
}
