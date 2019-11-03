using Blogger.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Application.Queries.Interfaces
{
    public interface IArticleQueryService
    {
        Task<List<ArticleDto>> GetList();
    }
}
