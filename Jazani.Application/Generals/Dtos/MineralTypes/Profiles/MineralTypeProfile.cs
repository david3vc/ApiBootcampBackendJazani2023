using AutoMapper;
using Jazani.Application.Generals.Dtos.MineralTypes.Profiles.Mappers;
using Jazani.Core.Paginations;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.MineralTypes.Profiles
{
    public class MineralTypeProfile : Profile
    {
        public MineralTypeProfile()
        {
            CreateMap<MineralType, MineralTypeDto>();
            CreateMap<MineralType, MineralTypeDto>().ReverseMap();
            CreateMap<MineralType, MineralTypeSimpleDto>();

            CreateMap<MineralType, MineralTypeSaveDto>().ReverseMap();

            CreateMap<ResponsePagination<MineralType>, ResponsePagination<MineralTypeDto>>();
            CreateMap<RequestPagination<MineralType>, RequestPagination<MineralTypeDto>>()
                .ReverseMap();
                //.AfterMap<MineralTypeReverseMapper>();
        }
    }
}
