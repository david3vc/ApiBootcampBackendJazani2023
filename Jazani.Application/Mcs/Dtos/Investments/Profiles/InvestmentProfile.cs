using AutoMapper;
using Jazani.Core.Paginations;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Application.Mcs.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, InvestmentDto>();
            CreateMap<Investment, InvestmentDto>().ReverseMap();

            CreateMap<Investment, InvestmentSaveDto>().ReverseMap();

            CreateMap<Investment, InvestmentFilterDto>().ReverseMap();

            CreateMap<ResponsePagination<Investment>, ResponsePagination<InvestmentDto>>();
            CreateMap<RequestPagination<Investment>, RequestPagination<InvestmentFilterDto>>().ReverseMap();
        }
    }
}
