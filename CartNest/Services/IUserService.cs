using CartNest.Core.DTOs;
using CartNest.DTOs;
using CartNest.Models.Entities;

namespace CartNest.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterDto dto);

        Task<User?> LoginAsync(LoginDto dto);
    }
}