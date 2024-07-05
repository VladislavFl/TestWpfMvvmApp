using TestWpfMvvmApp.Model;

namespace TestWpfMvvmApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> LoginAsync(string username, string password);
        Task<bool> LogoutAsync();
        Task<bool> RegisterAsync(User user);
        Task<User> GetUserDataAsync(string username);
    }
}
