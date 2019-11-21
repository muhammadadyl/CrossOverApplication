using System;

namespace CrossOverApplication.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedON { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
