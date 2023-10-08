using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.PersonTypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class PersonTypeService : IPersonTypeService
    {
        private readonly IPersonTypeRepository _personTypeRepository;
        private readonly IMapper _mapper;

        public PersonTypeService(IPersonTypeRepository personTypeRepository, IMapper mapper)
        {
            _personTypeRepository = personTypeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<PersonTypeDto>> FindAllAsync()
        {
            IReadOnlyList<PersonType> mineralTypes = await _personTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<PersonTypeDto>>(mineralTypes);
        }

        public async Task<PersonTypeDto> FindByIdAsync(int id)
        {
            PersonType? personType = await _personTypeRepository.FindByIdAsync(id);

            if (personType is null) throw PersonTypeNotFound(id);

            return _mapper.Map<PersonTypeDto>(personType);
        }

        private NotFoundCoreException PersonTypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de persona no encontrado para el id: " + id);
        }
    }
}
