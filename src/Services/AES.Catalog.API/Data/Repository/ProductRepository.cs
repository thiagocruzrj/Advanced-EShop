using AES.Catalog.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AES.Catalog.API.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
