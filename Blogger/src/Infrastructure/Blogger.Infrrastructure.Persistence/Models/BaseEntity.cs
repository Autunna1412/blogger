using System;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Infrastructure.Persistence.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        [ConcurrencyCheck]
        public byte[] RowVersion { get; set; }

        //[Required]
        public string CreatedBy { get; set; }

        //[Required]
        public DateTime? CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted;
    }
}
