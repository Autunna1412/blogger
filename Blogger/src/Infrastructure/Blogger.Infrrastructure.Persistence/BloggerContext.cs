using Blogger.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Infrastructure.Persistence
{
    public class BloggerContext : DbContext
    {
        public BloggerContext(DbContextOptions<BloggerContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
