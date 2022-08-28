using Core.Interfaces.Common;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _context;
        public UnitOfWork(ProjectContext context)
        {
            this._context = context;
        }
        public async Task<bool> CompleteAsync()
        {
            try
            {
                return (await _context.SaveChangesAsync() >= 0);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
