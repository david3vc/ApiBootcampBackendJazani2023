using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Nationalities.Mappers
{
    public class NationalityMapper : Profile
    {
        public NationalityMapper()
        {
            CreateMap<Nationality, NationalityDto>();
        }
    }
}
