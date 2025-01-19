using JWTAuth.Model;
using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Services
{
    public interface IAuthService
    {
        JwtTokenResponse GenerateToken(User user);
    }
}