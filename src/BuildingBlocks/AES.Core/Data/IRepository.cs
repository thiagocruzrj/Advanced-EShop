using AES.Core.DomainObjects;
using System;

namespace AES.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {

    }
}
