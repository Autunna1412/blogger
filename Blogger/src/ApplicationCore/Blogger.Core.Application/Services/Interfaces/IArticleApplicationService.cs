using Blogger.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Application.Services.Interfaces
{
    public interface IArticleApplicationService
    {
        void CreateAsync(ArticleDto dto);
        Task<ArticleDto> GetByIdAsync(int id);
    }
}
