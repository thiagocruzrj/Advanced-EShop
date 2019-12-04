using System;

namespace IntegratorSeven.Api.Domain.Repository
{
    public interface ISibelPropriedade
    {
         void GetPropriedade(long id, DateTime dtEvento);
    }
}