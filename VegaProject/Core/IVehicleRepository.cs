using System.Threading.Tasks;
using VegaProject.Core.DomainModels;

namespace VegaProject.Core
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int? id, bool includeRelated = true);
         void Add(Vehicle vehicle);
         void Remove(Vehicle vehicle);
    }
}