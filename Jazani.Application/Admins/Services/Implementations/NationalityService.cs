using AutoMapper;
using Jazani.Application.Admins.Dtos.Nationalities;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class NationalityService : INationalityService
    {
        private readonly INationalityRepository _nationalityRepository;
        private readonly IMapper _mapper;

        public NationalityService(INationalityRepository nationalityRepository, IMapper mapper)
        {
            _nationalityRepository = nationalityRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<NationalityDto>> FindAllAsync()
        {
            IReadOnlyList<Nationality> nationalities = await _nationalityRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<NationalityDto>>(nationalities);
        }

        public async Task<NationalityDto?> FindByIdAsync(int id)
        {
            Nationality? nationality = await _nationalityRepository.FindByIdAsync(id);

            return _mapper.Map<NationalityDto>(nationality);
        }

        public async Task<NationalityDto> CreateAsync(NationalitySaveDto nationalitySaveDto)
        {
            Nationality nationality = _mapper.Map<Nationality>(nationalitySaveDto);
            nationality.RegistrationDate = DateTimeOffset.Now;
            nationality.State = true;

            Nationality nationalitySaved = await _nationalityRepository.SaveAsync(nationality);

            return _mapper.Map<NationalityDto>(nationalitySaved);
        }

        public async Task<NationalityDto> EditAsync(int id, NationalitySaveDto nationalitySaveDto)
        {
            Nationality nationality = await _nationalityRepository.FindByIdAsync(id);

            _mapper.Map<NationalitySaveDto, Nationality>(nationalitySaveDto, nationality);

            Nationality nationalitySaved = await _nationalityRepository.SaveAsync(nationality);

            return _mapper.Map<NationalityDto>(nationalitySaved);
        }

        public async Task<NationalityDto> DisabledAsync(int id)
        {
            Nationality nationality = await _nationalityRepository.FindByIdAsync(id);
            nationality.State = false;

            Nationality nationalitySaved = await _nationalityRepository.SaveAsync(nationality);

            return _mapper.Map<NationalityDto>(nationalitySaved);
        }
    }
}
