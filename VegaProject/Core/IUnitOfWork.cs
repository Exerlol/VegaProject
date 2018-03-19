using System.Threading.Tasks;

namespace VegaProject.Core
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}