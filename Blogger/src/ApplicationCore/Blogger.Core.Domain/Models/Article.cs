using System.Collections.Generic;
using Blogger.Core.Domain.Enums;

namespace Blogger.Core.Domain.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string  Hashtags { get; set; }
        public AppEnums.ArticleType? Type { get; set; }
    }
}
