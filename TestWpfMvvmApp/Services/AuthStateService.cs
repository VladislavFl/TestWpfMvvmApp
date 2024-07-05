using TestWpfMvvmApp.Services.Interfaces;

namespace TestWpfMvvmApp.Services
{
    public class AuthStateService : IAuthStateService
    {
        public bool IsUserAuthorized { get; set; }

        public void SetUserAuthorized(bool isAuthorized)
        {
            IsUserAuthorized = isAuthorized;
        }
    }
}
