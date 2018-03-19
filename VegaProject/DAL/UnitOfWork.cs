using System.Threading.Tasks;
using VegaProject.Core;

namespace VegaProject.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaDbContext _vegaDbContext;

        public UnitOfWork(VegaDbContext vegaDbContext)
        {
            _vegaDbContext = vegaDbContext;
        }

        public async Task CompleteAsync()
        {
            await _vegaDbContext.SaveChangesAsync();
        }
    }
}