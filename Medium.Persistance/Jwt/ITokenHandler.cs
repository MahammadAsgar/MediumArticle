using Medium.Domain.Users;

namespace Medium.Persistance.Jwt
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(AppUser user);
    }
}
