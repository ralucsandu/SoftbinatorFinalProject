using FinalProject.Entities;

namespace FinalProject.Managers
{
    public interface ITokenManager
    {
        Task<string> CreateToken(User user);
    }
}
