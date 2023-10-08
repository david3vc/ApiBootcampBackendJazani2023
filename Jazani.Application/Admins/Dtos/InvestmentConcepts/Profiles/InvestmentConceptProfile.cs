using AutoMapper;
using Jazani.Application.Admins.Dtos.Nationalities;
using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.InvestmentConcepts.Profiles
{
    public class InvestmentConceptProfile : Profile
    {
        public InvestmentConceptProfile()
        {
            CreateMap<InvestmentConcept, InvestmentConceptDto>();
            CreateMap<InvestmentConcept, InvestmentConceptSimpleDto>();

            CreateMap<InvestmentConcept, InvestmentConceptSaveDto>().ReverseMap();
        }
    }
}
