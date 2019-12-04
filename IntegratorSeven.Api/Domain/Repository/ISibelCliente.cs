using System;

namespace IntegratorSeven.Api.Domain.Repository
{
    public interface ISibelCliente
    {
         void GetCliente(long id, DateTime dtEvento);
    }
}