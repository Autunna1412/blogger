using Blogger.Core.Application.Dtos;
using Blogger.Core.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            _articleService.CreateAsync(dto);
            return Ok();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Create(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var result = await _articleService.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
