using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Nationalities.Profiles
{
    public class NationalityProfile : Profile
    {
        public NationalityProfile()
        {
            CreateMap<Nationality, NationalityDto>();
            CreateMap<Nationality, NationalitySimpleDto>();

            CreateMap<Nationality, NationalitySaveDto>().ReverseMap();
        }
    }
}
