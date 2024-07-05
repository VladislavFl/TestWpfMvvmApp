using TestWpfMvvmApp.Services.Interfaces;

namespace TestWpfMvvmApp.Services
{
    public class AuthStateService : IAuthStateService
    {
        public bool IsUserAuthorized { get; set; }
        public string Username { get; set; } = string.Empty;
        public event EventHandler? UserAuthorized;
        public event EventHandler? UserNonAuthorized;

        public void SetUserAuthorized(bool isAuthorized, string username)
        {
            IsUserAuthorized = isAuthorized;
            Username = username;

            if (isAuthorized == true)
            {
                UserAuthorized?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                UserNonAuthorized?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
