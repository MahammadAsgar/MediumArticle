using AutoMapper;
using Medium.Domain.Users;
using Medium.Infrasturucture.Dtos.Users.Get;
using Medium.Infrasturucture.Dtos.Users.Post;
using Medium.Infrasturucture.Services.Users.Abstractions;
using Medium.Persistance.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Result;

namespace Medium.Infrasturucture.Services.Users.Implementations
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IMapper _mapper;
        readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
            IMapper mapper, ITokenHandler tokenHandler, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AppUser> GetCurrentUser()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            return user;
        }

        public async Task<Response<NoDataDto>> Register(RegistrUserDto registrUserDto)
        {
            var user = _mapper.Map<AppUser>(registrUserDto);
            var response = await _userManager.CreateAsync(user, registrUserDto.Password);
            if (response.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return Response<NoDataDto>.Success("Registerd Successful");
            }
            return Response<NoDataDto>.Fail("Registerd Unsuccessful");
        }

        public async Task<Response<Token>> SignIn(LoginUserDto loginUserDto)
        {
            AppUser user = await _userManager.FindByNameAsync(loginUserDto.UserName);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginUserDto.Email);
            }

            if (user == null)
            {
                return Response<Token>.Fail("User not found");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, false);
            if (result.Succeeded) //Success Authentication
            {
                //var claims = await _userManager.GetClaimsAsync(user);
                Token token =await _tokenHandler.CreateAccessToken(user);
                return Response<Token>.Success(token);
            }
            return Response<Token>.Fail("password is incorrect");
        }

        public async Task<Response<NoDataDto>> SignOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Response<NoDataDto>.Success("Signout Successfull");
            }
            catch (Exception)
            {

                return Response<NoDataDto>.Fail("Signout Unsuccessfull");
            }
        }

        //get
        public async Task<Response<GetUserAll>> GetUserAll(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user != null)
            {
                var response = _mapper.Map<GetUserAll>(user);
                return Response<GetUserAll>.Success(response);
            }
            return Response<GetUserAll>.Fail("user not found");
        }

        public async Task<Response<GetUserOwnInfo>> GetUserOwnInfo(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user != null)
            {
                var response = _mapper.Map<GetUserOwnInfo>(user);
                return Response<GetUserOwnInfo>.Success(response);
            }
            return Response<GetUserOwnInfo>.Fail("User not found");
        }

        public async Task<Response<IEnumerable<GetUserOnList>>> GetUserOnList()
        {
            var users =  _userManager.Users;
            if (users != null)
            {
                var response = _mapper.Map<IEnumerable<GetUserOnList>>(users);
                return Response<IEnumerable<GetUserOnList>>.Success(response);
            }
            return Response<IEnumerable<GetUserOnList>>.Fail("No data found");
        }
    }
}
