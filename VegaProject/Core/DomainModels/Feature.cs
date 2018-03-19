using System.Collections.Generic;

namespace VegaProject.Core.DomainModels
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<VehicleFeature> VehicleFeatures { get; set; }
    }
}