using System;
using System.Collections.Generic;
using System.Text;

namespace CrossOverApplication.Core.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ImageID { get; set; }
        public virtual Image Image { get; set; }
    }
}
