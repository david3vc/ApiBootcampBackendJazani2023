using AutoMapper;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Application.Mcs.Dtos.InvestmentTypes.Profiles
{
    public class InvestmentTypeProfile : Profile
    {
        public InvestmentTypeProfile()
        {
            CreateMap<InvestmentType, InvestmentTypeDto>();
            CreateMap<InvestmentType, InvestmentTypeSimpleDto>();

            CreateMap<InvestmentType, InvestmentTypeSaveDto>().ReverseMap();
        }
    }
}
