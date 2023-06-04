using Medium.Domain.Users;

namespace Medium.Persistance.Jwt
{
    public interface ITokenHandler
    {
        Task<Token> CreateAccessToken(AppUser user);
    }
}
