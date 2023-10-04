using AutoMapper;
using Jazani.Application.Admins.Dtos.Offices;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.MineralTypes.Profiles
{
    public class MineralTypeProfile : Profile
    {
        public MineralTypeProfile()
        {
            CreateMap<MineralType, MineralTypeDto>();
            CreateMap<MineralType, MineralTypeSaveDto>().ReverseMap();
        }
    }
}
