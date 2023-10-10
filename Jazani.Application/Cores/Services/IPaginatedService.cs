using Jazani.Core.Paginations;

namespace Jazani.Application.Cores.Services
{
    public interface IPaginatedService<TDto, TDtoFilter>
    {
        Task<ResponsePagination<TDto>> PaginationSearch(RequestPagination<TDtoFilter> request);
    }
}
