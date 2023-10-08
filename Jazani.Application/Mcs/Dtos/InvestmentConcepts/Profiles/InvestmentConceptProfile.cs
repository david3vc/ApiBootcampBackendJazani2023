using AutoMapper;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Application.Mcs.Dtos.InvestmentConcepts.Profiles
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
