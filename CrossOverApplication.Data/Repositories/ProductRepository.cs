using CrossOverApplication.Core.Data;
using CrossOverApplication.Core.Data.Interfaces.Repositories;
using CrossOverApplication.Core.Domain.Entities;
using CrossOverApplication.Data.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossOverApplication.Data.Repositories
{
    public class ProductRepository : EntityRepository<Product>, IProductRepository
    {
        public ProductRepository(IEntitiesContext context) : base(context)
        {
        }

        public bool SetDelete(int id)
        {
            var product = GetSingle(id);
            if (product != null)
            {
                product.IsDeleted = true;
                Update(product);
                
                return true;
            }
            return false;
        }
    }
}
