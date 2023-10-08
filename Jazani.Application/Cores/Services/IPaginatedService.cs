using Jazani.Core.Paginations;

namespace Jazani.Application.Cores.Services
{
    public interface IPaginatedService<TDto>
    {
        Task<ResponsePagination<TDto>> PaginationSearch(RequestPagination<TDto> request);
    }
}
