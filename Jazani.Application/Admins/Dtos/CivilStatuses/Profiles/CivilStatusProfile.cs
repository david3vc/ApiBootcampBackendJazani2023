using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.CivilStatuses.Profiles
{
    public class CivilStatusProfile : Profile
    {
        public CivilStatusProfile()
        {
            CreateMap<CivilStatus, CivilStatusDto>();
            CreateMap<CivilStatus, CivilStatusSimpleDto>();

            CreateMap<CivilStatus, CivilStatusSaveDto>().ReverseMap();
        }
    }
}
