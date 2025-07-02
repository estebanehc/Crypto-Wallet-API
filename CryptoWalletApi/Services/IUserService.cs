namespace CryptoWalletApi.Services
{
    using CryptoWalletApi.DTOs;

    public interface IUserService
    {
        Task<bool> RegisterAsync(UserRegisterDto dto);
        Task<string> LoginAsync(UserLoginDto dto);
    }
}
