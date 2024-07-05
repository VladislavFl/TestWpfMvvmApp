namespace TestWpfMvvmApp.Services.Interfaces
{
    public interface IAuthStateService
    {
        bool IsUserAuthorized { get; set; }
        string Username { get; set; }

        event EventHandler? UserAuthorized;
        event EventHandler? UserNonAuthorized;

        void SetUserAuthorized(bool isAuthorized, string username);
    }
}
