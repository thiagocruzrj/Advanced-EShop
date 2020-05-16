using AES.Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AES.Catalog.API.Controllers
{
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
