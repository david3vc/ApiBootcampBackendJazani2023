using AutoMapper;
using Jazani.Application.Dls.Dtos.Documents;
using Jazani.Application.Generals.Dtos.MeasureUnits;
using Jazani.Application.Generals.Dtos.PeriodTypes;
using Jazani.Application.Mcs.Dtos.InvestmentConcepts;
using Jazani.Application.Mcs.Dtos.InvestmentTypes;
using Jazani.Application.Mcs.Dtos.MiningConcessions;
using Jazani.Application.Socs.Dtos.Holders;
using Jazani.Core.Paginations;
using Jazani.Domain.Dls.Models;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Socs.Models;

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

            CreateMap<MiningConcession, MiningConcessionSimpleDto>();
            CreateMap<Document, DocumentSimpleDto>();
            CreateMap<Holder, HolderSimpleDto>();
            CreateMap<InvestmentType, InvestmentTypeSimpleDto>();
            CreateMap<PeriodType, PeriodTypeSimpleDto>();
            CreateMap<MeasureUnit, MeasureUnitSimpleDto>();
            CreateMap<InvestmentConcept, InvestmentConceptSimpleDto>();

            CreateMap<ResponsePagination<Investment>, ResponsePagination<InvestmentDto>>();
            CreateMap<RequestPagination<Investment>, RequestPagination<InvestmentFilterDto>>().ReverseMap();
        }
    }
}
