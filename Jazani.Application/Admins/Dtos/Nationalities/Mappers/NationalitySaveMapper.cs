using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Nationalities.Mappers
{
    public class NationalitySaveMapper : Profile
    {
        public NationalitySaveMapper()
        {
            CreateMap<Nationality, NationalitySaveDto>().ReverseMap();
        }
    }
}
