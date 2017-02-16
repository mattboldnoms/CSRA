using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRA.Data.DataModels;
using CSRA.Models;
using CSRA.Models.ReceptionViewModels;
using AutoMapper;

namespace CSRA.Mappers
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Prisoner, PrisonerListItemViewModel>()
                .ForMember(dest => dest.FromLocation,
               opts => opts.MapFrom(src => src.FromLocation.Name));
            ;
        }
    }
}
