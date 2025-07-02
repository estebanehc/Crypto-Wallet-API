namespace CryptoWalletApi.Repositories
{
    using CryptoWalletApi.Models;
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
