﻿using AutoMapper;
using Jazani.Core.Paginations;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.MineralTypes.Profiles.Mappers
{
    public class MineralTypeMapper : IMappingAction<RequestPagination<MineralType>, RequestPagination<MineralTypeDto>>
    {
        public void Process(RequestPagination<MineralType> source, RequestPagination<MineralTypeDto> destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}