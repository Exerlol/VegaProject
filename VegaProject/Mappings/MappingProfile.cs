using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VegaProject.Controllers.Resources_DTOs;
using VegaProject.Core.DomainModels;

namespace VegaProject.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resources
            CreateMap<Make,MakeResource>();
            CreateMap<Model,KeyValuePairResource>();
            CreateMap<Feature,KeyValuePairResource>();
            CreateMap<Vehicle,SaveVehicleResource>().ForMember(vr => vr.Contact, 
                                                           opt => opt.MapFrom(v => new ContactResource{Name = v.ContactName, Phone = v.ContactPhone, Email = v.ContactEmail}))
                                                .ForMember(vr => vr.Features, opt => opt.MapFrom(v=> v.Features.Select(vf=> vf.FeatureId)));
                                                
            CreateMap<Vehicle,VehicleResource>().ForMember(vr => vr.Make, opt => opt.MapFrom(v => new KeyValuePairResource{ Id = v.Model.MakeId, Name = v.Model.Make.Name }))
                                                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource{ Name = v.ContactName, Phone = v.ContactPhone, Email = v.ContactEmail }))
                                                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new KeyValuePairResource{ Id = vf.FeatureId, Name = vf.Feature.Name})));
            

            // API Resources to Domain
            CreateMap<SaveVehicleResource,Vehicle>().ForMember(v => v.Id, opt => opt.Ignore())
                                                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr=> vr.Contact.Name))
                                                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr=> vr.Contact.Phone))
                                                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr=> vr.Contact.Email))
                                                .ForMember(v => v.Features, opt => opt.Ignore())
                                                .AfterMap((vr,v) => {
                                                    // var removedFeatures = new List<VehicleFeature>();
                                                    // //remove unselected features
                                                    // foreach(var f in v.Features)
                                                    //     if(!vr.Features.Contains(f.FeatureId))
                                                    //         removedFeatures.Add(f);

                                                    // foreach(var rf in removedFeatures){
                                                    //         v.Features.Remove(rf);
                                                    // }

                                                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                                                    foreach(var f in removedFeatures)
                                                            v.Features.Remove(f);

                                                    // // add new features
                                                    // foreach (var id in vr.Features)
                                                    //     if(!v.Features.Any(f=> f.FeatureId == id))
                                                    //         v.Features.Add(new VehicleFeature{FeatureId = id});

                                                    var addedFeatures = vr.Features.Where(id => !v.Features.Any(f=> f.FeatureId == id))
                                                                                   .Select(id => new VehicleFeature{FeatureId = id});
                                                     foreach(var f in addedFeatures)
                                                           v.Features.Add(f);

                                                });
                                                
        }
    }
}