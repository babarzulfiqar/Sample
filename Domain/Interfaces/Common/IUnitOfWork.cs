using System.Threading.Tasks;

namespace Core.Interfaces.Common
{
    public interface IUnitOfWork
    {
        Task<bool> CompleteAsync();
    }
}
