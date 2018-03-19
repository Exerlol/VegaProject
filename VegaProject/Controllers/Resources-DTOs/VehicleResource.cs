using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VegaProject.Controllers.Resources_DTOs
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public KeyValuePairResource Model { get; set; }
        public KeyValuePairResource Make { get; set; }
        public bool Registered { get; set; }
        public ContactResource Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<KeyValuePairResource> Features { get; set; }

        public VehicleResource()
        {
           Features = new Collection<KeyValuePairResource>();
        }
    }
}