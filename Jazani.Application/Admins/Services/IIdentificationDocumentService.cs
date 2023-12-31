﻿using Jazani.Application.Admins.Dtos.IdentificationDocuments;

namespace Jazani.Application.Admins.Services
{
    public interface IIdentificationDocumentService
    {
        Task<IReadOnlyList<IdentificationDocumentDto>> FindAllAsync();
        Task<IdentificationDocumentDto?> FindByIdAsync(int id);
        Task<IdentificationDocumentDto> CreateAsync(IdentificationDocumentSaveDto identificationDocumentSaveDto);
        Task<IdentificationDocumentDto> EditAsync(int id, IdentificationDocumentSaveDto identificationDocumentSaveDto);
        Task<IdentificationDocumentDto> DisabledAsync(int id);
    }
}
