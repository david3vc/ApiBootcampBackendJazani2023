using Jazani.Core.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Cores.Services
{
    public interface IPaginatedService<TDto>
    {
        Task<ResponsePagination<TDto>> PaginationSearch(RequestPagination<TDto> request);
    }
}
