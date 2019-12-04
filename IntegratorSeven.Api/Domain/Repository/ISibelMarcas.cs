using System;

namespace IntegratorSeven.Api.Domain.Repository
{
    public interface ISibelMarcas
    {
         void GetMarcas(long id, DateTime dtEvento);
    }
}