﻿using Jazani.Application.Cores.Services;
using Jazani.Application.Generals.Dtos.PersonTypes;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services
{
    public interface IPersonTypeService : IQueryService<PersonTypeDto, int>
    {
    }
}