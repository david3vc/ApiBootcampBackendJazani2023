using AutoMapper;
using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.PersonTypes.Profiles
{
    public class PersonTypeProfile : Profile
    {
        public PersonTypeProfile()
        {
            CreateMap<PersonType, PersonTypeDto>();
            CreateMap<PersonType, PersonTypeSaveDto>().ReverseMap();
        }
    }
}
