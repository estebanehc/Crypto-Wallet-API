using CryptoWalletApi.Models;

namespace CryptoWalletApi.Utils
{
    public interface IJwtUtils
    {
        string GenerateToken(User user);
    }
}
