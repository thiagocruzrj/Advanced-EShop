using AES.BFF.Purchases.Models;
using System;
using System.Threading.Tasks;

namespace AES.BFF.Purchases.Services
{
    public interface ICatalogService 
    {
        Task<ProductItemDTO> GetById(Guid id);
    }
}