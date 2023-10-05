using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Minerals.profiles
{
    public class MineralProfile : Profile
    {
        public MineralProfile()
        {
            CreateMap<Mineral, MineralDto>();
            CreateMap<Mineral, MineralSaveDto>().ReverseMap();
        }
    }
}
