using AES.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public class CatalogService : ICatalogService
    {
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
