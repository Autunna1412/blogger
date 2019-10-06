using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Infrastructure.Persistence.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
