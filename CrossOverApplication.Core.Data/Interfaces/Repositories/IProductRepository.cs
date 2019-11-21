using CrossOverApplication.Core.Data.Interfaces.Generic.Repositories;
using CrossOverApplication.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossOverApplication.Core.Data.Interfaces.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        bool SetDelete(int id);
    }
}
