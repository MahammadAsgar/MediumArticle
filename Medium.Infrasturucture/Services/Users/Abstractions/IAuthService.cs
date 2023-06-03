using Medium.Domain.Users;
using Medium.Infrasturucture.Dtos.Users.Get;
using Medium.Infrasturucture.Dtos.Users.Post;
using Medium.Persistance.Jwt;
using Result;

namespace Medium.Infrasturucture.Services.Users.Abstractions
{
    public interface IAuthService
    {
        Task<Response<NoDataDto>> Register(RegistrUserDto registrUserDto);
       // Task<Response<IEnumerable<GetUserAll>>> GetUsers();
        Task<Response<Token>> SignIn(LoginUserDto loginUserDto);
        Task<Response<NoDataDto>> SignOut();
        Task<AppUser> GetCurrentUser();
        Task<Response<GetUserAll>> GetUserAll(int userId);
        Task<Response<IEnumerable<GetUserOnList>>> GetUserOnList();
        Task<Response<GetUserOwnInfo>> GetUserOwnInfo(int userId);
    }
}
