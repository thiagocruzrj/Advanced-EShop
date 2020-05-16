using System;

namespace AES.Core.DomainObjects
{
    public interface IRepository<T> : IDisposable where T : Entity
    {

    }

    public interface IAggreagateRoot { }
}
