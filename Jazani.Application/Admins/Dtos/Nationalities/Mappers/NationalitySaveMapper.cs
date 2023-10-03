﻿using AutoMapper;
using Jazani.Application.Admins.Dtos.Offices;
using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.Nationalities.Mappers
{
    public class NationalitySaveMapper : Profile
    {
        public NationalitySaveMapper()
        {
            CreateMap<Nationality, NationalitySaveDto>().ReverseMap();
        }
    }
}