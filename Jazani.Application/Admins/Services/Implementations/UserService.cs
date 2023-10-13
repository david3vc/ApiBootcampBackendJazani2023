using AutoMapper;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Core.Securities.Services;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;

        public UserService(IUserRepository userRepository, IMapper mapper, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _securityService = securityService;
        }

        public async Task<UserDto> CreateAsync(UserSaveDto userSaveDto)
        {
            User user = _mapper.Map<User>(userSaveDto);
            user.RegistrationDate = DateTime.Now;
            user.State = true;

            user.Password = _securityService.HashPassword(user.Email, user.Password);

            User userSaved = await _userRepository.SaveAsync(user);

            return _mapper.Map<UserDto>(userSaved);
        }

        public Task<UserDto> EditAsync(int id, UserSaveDto userSaveDto)
        {
            //User user = await _userRepository.FindByIdAsync(id);

            //_mapper.Map<UserSaveDto, User>(userSaveDto, user);

            //User userSaved = await _userRepository.SaveAsync(user);

            //return _mapper.Map<UserDto>(userSaved);
            throw new NotImplementedException();
        }
    }
}
