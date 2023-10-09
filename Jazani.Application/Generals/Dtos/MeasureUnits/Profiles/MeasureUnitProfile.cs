using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.MeasureUnits.Profiles
{
    public class MeasureUnitProfile : Profile
    {
        public MeasureUnitProfile()
        {
            CreateMap<MeasureUnit, MeasureUnitDto>();
            CreateMap<MeasureUnit, MeasureUnitSimpleDto>();

            CreateMap<MeasureUnit, MeasureUnitSaveDto>().ReverseMap();
        }
    }
}
