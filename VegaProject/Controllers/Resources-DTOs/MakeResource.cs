using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VegaProject.Controllers.Resources_DTOs
{
    public class MakeResource : KeyValuePairResource
    {
        public MakeResource()
        {
            Models = new Collection<KeyValuePairResource>();
        }
        public ICollection<KeyValuePairResource> Models { get; set; }
    }
}