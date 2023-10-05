using AutoMapper;
using Jazani.Application.Admins.Dtos.CivilStatuses;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class CivilStatusService : ICivilStatusService
    {
        private readonly ICivilStatusRepository _civilStatusRepository;
        private readonly IMapper _mapper;

        public CivilStatusService(ICivilStatusRepository civilStatusRepository, IMapper mapper)
        {
            _civilStatusRepository = civilStatusRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CivilStatusDto>> FindAllAsync()
        {
            IReadOnlyList<CivilStatus> civilStatuss = await _civilStatusRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<CivilStatusDto>>(civilStatuss);
        }

        public async Task<CivilStatusDto?> FindByIdAsync(int id)
        {
            CivilStatus? civilStatus = await _civilStatusRepository.FindByIdAsync(id);

            return _mapper.Map<CivilStatusDto>(civilStatus);
        }

        public async Task<CivilStatusDto> CreateAsync(CivilStatusSaveDto civilStatusSaveDto)
        {
            CivilStatus civilStatus = _mapper.Map<CivilStatus>(civilStatusSaveDto);
            civilStatus.RegistrationDate = DateTime.Now;
            civilStatus.State = true;

            CivilStatus civilStatusSaved = await _civilStatusRepository.SaveAsync(civilStatus);

            return _mapper.Map<CivilStatusDto>(civilStatusSaved);
        }

        public async Task<CivilStatusDto> EditAsync(int id, CivilStatusSaveDto civilStatusSaveDto)
        {
            CivilStatus civilStatus = await _civilStatusRepository.FindByIdAsync(id);

            _mapper.Map<CivilStatusSaveDto, CivilStatus>(civilStatusSaveDto, civilStatus);

            CivilStatus civilStatusSaved = await _civilStatusRepository.SaveAsync(civilStatus);

            return _mapper.Map<CivilStatusDto>(civilStatusSaved);
        }

        public async Task<CivilStatusDto> DisabledAsync(int id)
        {
            CivilStatus civilStatus = await _civilStatusRepository.FindByIdAsync(id);
            civilStatus.State = false;

            CivilStatus civilStatusSaved = await _civilStatusRepository.SaveAsync(civilStatus);

            return _mapper.Map<CivilStatusDto>(civilStatusSaved);
        }
    }
}
