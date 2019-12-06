using AutoMapper;
using Square.Connect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHands.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Models.Customer, Square.Connect.Model.Customer>();
            CreateMap<Models.Customer, CreateCustomerRequest>()
                .ForMember(x => x.Birthday,
                            m => m.MapFrom(a => a.Birthday.ToUniversalTime().ToString("yyyy-MM-dd'T'00:00:00")))
                //.ForMember(x => x.Address.AddressLine1,
                //            m => m.MapFrom(a => a.Address))
                //.ForMember(x => x.Address.FirstName,
                //            m => m.MapFrom(a => a.GivenName))
                //.ForMember(x => x.Address.LastName,
                //            m => m.MapFrom(a => a.FamilyName))
                //.ForMember(x => x.Address.PostalCode,
                //            m => m.MapFrom(a => a.PostalCode))
                //.ForMember(x => x.Address.Locality,
                //            m => m.MapFrom(a => a.City))
                //.ForMember(x => x.Address.AdministrativeDistrictLevel1,
                //            m => m.MapFrom(a => a.State))
                            ; //1998-09-01T00:00:00-00:00`
            CreateMap<Square.Connect.Model.Customer, Models.Customer> ();


        }
    }
}
