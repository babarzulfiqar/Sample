using Core.Common;
using Core.Interfaces.Common;
using Core.Interfaces.Generic;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepo<T> where T : AuditableEntity
    {
        private readonly ProjectContext _context;

        public GenericRepository(ProjectContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
        public void AddRecord(T entity)
        {
            _context.AddAsync(entity);
        }
        public bool DeleteRecord(T entity)
        {
            _context.Set<T>().Attach(entity);
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.CreatedById).IsModified = false;
            _context.Entry(entity).Property(x => x.CreatedOn).IsModified = false;
            return true;
        }
        public bool UpdateRecord(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.CreatedById).IsModified = false;
            _context.Entry(entity).Property(x => x.CreatedOn).IsModified = false;
            _context.Entry(entity).Property(x => x.IsDeleted).IsModified = false;
            return true;
        }
    }
}
