using TestWpfMvvmApp.Services.Interfaces;

namespace TestWpfMvvmApp.Services
{
    public class AuthService
    {
        private readonly IAuthStateService _authStateService;

        public AuthService(IAuthStateService authStateService)
        {
            _authStateService = authStateService;
        }

        public void SetUserAuthorized(bool isAuthorized)
        {
            _authStateService.IsUserAuthorized = isAuthorized;
        }

        public bool IsUserAuthorized()
        {
            return _authStateService.IsUserAuthorized;
        }
    }
}
