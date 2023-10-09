using AutoMapper;
using Jazani.Domain.Dls.Models;

namespace Jazani.Application.Dls.Dtos.Documents.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentDto>();
            CreateMap<Document, DocumentSimpleDto>();

            CreateMap<Document, DocumentSaveDto>().ReverseMap();
        }
    }
}
