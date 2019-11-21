using CrossOverApplication.Core.Data.Interfaces;
using CrossOverApplication.Core.Data.Interfaces.Repositories;
using CrossOverApplication.Core.Domain.Entities;
using CrossOverApplication.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossOverApplication.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private IProductRepository _productRepostory;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepostory) : base(unitOfWork)
        {
            _productRepostory = productRepostory;
        }

        public bool SetDelete(int id)
        {
            var status = _productRepostory.SetDelete(id);
            UnitOfWork.SaveChanges();

            return status;
        }
    }
}
