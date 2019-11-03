using Blogger.Core.Application.Dtos;
using Blogger.Core.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Blogger.Core.Domain.Enums.AppEnums;

namespace Blogger.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleApplicationService _articleService;

        public ArticleController(IArticleApplicationService articleApplicationService)
        {
            _articleService = articleApplicationService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]ArticleDto dto)
        {
            if(dto == null)
            {
                return BadRequest();
            }

            dto.CategoryId = 1;
            dto.Type = ArticleType.Image;
            dto.ImageUrl.Add("https://www.telegraph.co.uk/content/dam/Travel/2019/February/wat.jpg?imwidth=1400");
            dto.Hashtags.Add("Photography");
            _articleService.CreateAsync(dto);
            return Ok();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var result = await _articleService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("get/list")]
        public async Task<IActionResult> GetList()
        {
            var result = await _articleService.GetList();
            return Ok(result);
        }
    }
}
