using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VegaProject.Core;
using VegaProject.Core.DomainModels;

namespace VegaProject.DAL
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext _vegaDbContext;

        public VehicleRepository(VegaDbContext vegaDbContext)
        {
            _vegaDbContext = vegaDbContext;
        }
        public async Task<Vehicle> GetVehicle(int? id, bool includeRelated = true)
        {
            if(!includeRelated)
                return await _vegaDbContext.Vehicle.FindAsync(id);

            return await _vegaDbContext.Vehicle.Include(v => v.Features)
                                                            .ThenInclude(vf => vf.Feature)
                                                       .Include(m => m.Model)
                                                            .ThenInclude(m => m.Make)
                                                       .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            _vegaDbContext.Vehicle.Add(vehicle);
        }

         public void Remove(Vehicle vehicle)
        {
            _vegaDbContext.Remove(vehicle);
        }
    }
}