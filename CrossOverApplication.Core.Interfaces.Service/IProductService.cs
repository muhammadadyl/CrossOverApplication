using CrossOverApplication.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossOverApplication.Core.Interfaces.Services
{
    public interface IProductService: IService<Product>
    {
        bool SetDelete(int id);
    }
}
