using System;
using System.Collections.Generic;
using System.Text;
using Blogger.Core.Application.Extensions;
using Blogger.Infrastructure.Persistence.Models;
using static Blogger.Core.Domain.Enums.AppEnums;

namespace Blogger.Core.Application.Dtos
{
    public class ArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int CategoryId { get; set; }
        public List<string> Hashtags { get; set; }
        public ArticleType Type { get; set; }
        public string TypeName => EnumHelper<ArticleType>.GetDisplayValue(Type);
    }
}
