using AutoMapper;
using Blogger.Core.Application.Dtos;
using Blogger.Core.Application.Ports.Repository;
using Blogger.Core.Application.Queries.Interfaces;
using Blogger.Core.Application.Services.Interfaces;
using Blogger.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Application.Services
{
    public class ArticleApplicationService : IArticleApplicationService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IArticleQueryService _articleQueryService;

        public ArticleApplicationService(
            IArticleRepository articleRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IArticleQueryService articleQueryService)
        {
            _articleRepository = articleRepository;
            _articleQueryService = articleQueryService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Repositoy

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

        #endregion Repository

        #region QueryService
        public async Task<List<ArticleDto>> GetList()
        {
            var result = await this._articleQueryService.GetList();
            return result;
        }

        #endregion QueryService

        #region CommandService
        #endregion CommandService
    }
}
