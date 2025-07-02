namespace CryptoWalletApi.Services
{
    using CryptoWalletApi.DTOs;
    using CryptoWalletApi.Models;
    using CryptoWalletApi.Repositories;
    using CryptoWalletApi.Utils;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtUtils _jwt;

        public UserService(IUserRepository userRepo, IJwtUtils jwt)
        {
            _userRepo = userRepo;
            _jwt = jwt;
        }

        public async Task<bool> RegisterAsync(UserRegisterDto dto)
        {
            var existing = await _userRepo.GetByEmailAsync(dto.Email);
            if (existing != null) return false;

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = PasswordHasher.Hash(dto.Password)
            };

            await _userRepo.AddAsync(user);
            return true;
        }

        public async Task<string> LoginAsync(UserLoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if (user == null || !PasswordHasher.Verify(dto.Password, user.PasswordHash))
                return null;

            return _jwt.GenerateToken(user);
        }
    }
}
