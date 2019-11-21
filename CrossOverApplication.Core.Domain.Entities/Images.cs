using System;
using System.Collections.Generic;
using System.Text;

namespace CrossOverApplication.Core.Domain.Entities
{
    public sealed class Image : BaseEntity
    {
        public string Path { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
