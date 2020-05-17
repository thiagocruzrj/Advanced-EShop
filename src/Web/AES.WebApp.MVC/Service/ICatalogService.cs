using AES.WebApp.MVC.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public interface ICatalogService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(Guid id);
    }

    public interface ICatalogoServiceRefit
    {
        [Get("/catalogo/produtos/")]
        Task<IEnumerable<ProductViewModel>> ObterTodos();

        [Get("/catalogo/produtos/{id}")]
        Task<ProductViewModel> ObterPorId(Guid id);
    }
}