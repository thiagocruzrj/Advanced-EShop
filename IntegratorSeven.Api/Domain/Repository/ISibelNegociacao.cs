using System;

namespace IntegratorSeven.Api.Domain.Repository
{
    public interface ISibelNegociacao
    {
         void GetNegociacao(long id, DateTime dtEvento);
    }
}