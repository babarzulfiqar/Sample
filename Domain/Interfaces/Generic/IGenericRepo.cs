using Core.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces.Common;

namespace Core.Interfaces.Generic
{
    public interface IGenericRepo<T> where T : AuditableEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        void AddRecord(T entity);
        bool DeleteRecord(T entity);
        bool UpdateRecord(T entity);
    }
}
