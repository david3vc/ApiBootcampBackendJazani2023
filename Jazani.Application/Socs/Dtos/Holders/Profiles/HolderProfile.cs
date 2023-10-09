using AutoMapper;
using Jazani.Domain.Socs.Models;

namespace Jazani.Application.Socs.Dtos.Holders.Profiles
{
    public class HolderProfile : Profile
    {
        public HolderProfile()
        {
            CreateMap<Holder, HolderDto>();
            CreateMap<Holder, HolderSimpleDto>();
        }
    }
}
