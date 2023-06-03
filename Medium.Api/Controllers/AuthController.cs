using Medium.Infrasturucture.Dtos.Users.Get;
using Medium.Infrasturucture.Dtos.Users.Post;
using Medium.Infrasturucture.Services.Users.Abstractions;
using Medium.Persistance.Jwt;
using Microsoft.AspNetCore.Mvc;
using Result;

namespace Medium.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService _userService;
        public AuthController(IAuthService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<Response<NoDataDto>>> Register(RegistrUserDto registrUserDto)
        {
            var response = await _userService.Register(registrUserDto);
            return Ok(response);
        }

        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult<Response<Token>>> SignIn(LoginUserDto loginUserDto)
        {
            var response = await _userService.SignIn(loginUserDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<NoDataDto>>> SignOut()
        {
            var response = await _userService.SignOut();
            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Response<GetUserOwnInfo>>> UserInfo(int userId)
        {

            var response = await _userService.GetUserOwnInfo(userId);
            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Response<GetUserAll>>> User(int userId)
        {

            var response = await _userService.GetUserAll(userId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<GetUserOnList>>>> Users()
        {

            var response = await _userService.GetUserOnList();
            return Ok(response);
        }
    }
}
