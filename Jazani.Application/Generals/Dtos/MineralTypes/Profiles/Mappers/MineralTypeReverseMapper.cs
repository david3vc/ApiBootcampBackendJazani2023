using AutoMapper;
using Jazani.Core.Paginations;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.MineralTypes.Profiles.Mappers
{
    public class MineralTypeReverseMapper : IMappingAction<RequestPagination<MineralTypeDto>, RequestPagination<MineralType>>
    {
        public void Process(RequestPagination<MineralTypeDto> source, RequestPagination<MineralType> destination, ResolutionContext context)
        {
            if (source.Filter is not null)
            {
                destination.Filter = new MineralType()
                {
                    Name = source.Filter.Name,
                };
            }
        }
    }
}
