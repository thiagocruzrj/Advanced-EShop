using AES.Core.DomainObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AES.Catalog.API.Models
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        void Add(Product product);
        void Update(Product product);
    }
}
