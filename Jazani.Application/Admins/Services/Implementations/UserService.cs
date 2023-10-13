using AutoMapper;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Cores.Exceptions;
using Jazani.Core.Securities.Services;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Microsoft.Extensions.Configuration;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, ISecurityService securityService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _securityService = securityService;
            _configuration = configuration;
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

        public async Task<UserSecurityDto> LoginAsync(UserAuthDto userAuth)
        {
            User? user = await _userRepository.FindByEmailAsync(userAuth.Email);
            
            if (user == null) throw new NotFoundCoreException("Usuario no es está registrado en nuestro Sistema.");

            bool isCorrect = _securityService.VerifyHashedPassword(user.Email, user.Password, userAuth.Password);

            if (!isCorrect) throw new NotFoundCoreException("La contraseña que ingresó no es correcta.");

            if(!user.State) throw new NotFoundCoreException("Usuario no es está activo. Comuniquese con el administrador.");

            UserSecurityDto userSecurity = _mapper.Map<UserSecurityDto>(user);

            string jwtSecretKey = _configuration.GetSection("Security:JwtSecrectKey").Get<string>();

            userSecurity.Security = _securityService.JwtSecurity(jwtSecretKey);

            return userSecurity;
        }
    }
}
