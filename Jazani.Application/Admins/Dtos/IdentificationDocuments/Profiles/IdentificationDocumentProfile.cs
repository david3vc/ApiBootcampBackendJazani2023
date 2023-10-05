using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.IdentificationDocuments.Profiles
{
    public class IdentificationDocumentProfile : Profile
    {
        public IdentificationDocumentProfile()
        {
            CreateMap<IdentificationDocument, IdentificationDocumentDto>();
            CreateMap<IdentificationDocument, IdentificationDocumentSimpleDto>();

            CreateMap<IdentificationDocument, IdentificationDocumentSaveDto>().ReverseMap();
        }
    }
}
