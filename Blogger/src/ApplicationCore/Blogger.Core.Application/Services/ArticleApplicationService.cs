using AutoMapper;
using Blogger.Core.Application.Dtos;
using Blogger.Core.Application.Ports.Repository;
using Blogger.Core.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blogger.Infrastructure.Persistence.Models;

namespace Blogger.Core.Application.Services
{
    public class ArticleApplicationService : IArticleApplicationService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public ArticleApplicationService(IArticleRepository articleRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void CreateAsync(ArticleDto dto)
        {
            var article = _mapper.Map<Article>(dto);
            article.CreatedDate = DateTime.Now;

            _articleRepository.Add(article);
            _unitOfWork.SaveChanges();
        }

        public async Task<ArticleDto> GetByIdAsync(int id)
        {
            var model = await _articleRepository.GetByIdAsync(id);
            return _mapper.Map<ArticleDto>(model);
        }
    }
}
