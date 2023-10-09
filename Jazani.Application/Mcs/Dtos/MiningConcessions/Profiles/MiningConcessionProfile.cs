using AutoMapper;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Application.Mcs.Dtos.MiningConcessions.Profiles
{
    public class MiningConcessionProfile : Profile
    {
        public MiningConcessionProfile()
        {
            CreateMap<MiningConcession, MiningConcessionDto>();
            CreateMap<MiningConcession, MiningConcessionSimpleDto>();

            CreateMap<MiningConcession, MiningConcessionSaveDto>().ReverseMap();
        }
    }
}
