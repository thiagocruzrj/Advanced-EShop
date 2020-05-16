using System.Threading.Tasks;

namespace AES.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}