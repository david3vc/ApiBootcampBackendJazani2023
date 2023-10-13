using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/values
        [HttpPost]
        public async Task<Results<BadRequest, CreatedAtRoute<UserDto>>> Post([FromBody] UserSaveDto userSaveDto)
        {
            UserDto user = await _userService.CreateAsync(userSaveDto);

            return TypedResults.CreatedAtRoute(user);
        }
    }
}
