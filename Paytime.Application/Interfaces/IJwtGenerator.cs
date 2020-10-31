using Paytime.Domain;

namespace Paytime.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(UserModel user);
    }
}