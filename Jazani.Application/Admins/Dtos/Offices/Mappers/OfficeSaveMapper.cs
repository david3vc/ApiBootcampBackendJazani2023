using AutoMapper;
using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.Offices.Mappers
{
    public class OfficeSaveMapper : Profile
    {
        public OfficeSaveMapper()
        {
            CreateMap<Office, OfficeSaveDto>().ReverseMap();
        }
    }
}
