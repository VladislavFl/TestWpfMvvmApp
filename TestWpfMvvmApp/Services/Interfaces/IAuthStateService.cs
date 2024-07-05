namespace TestWpfMvvmApp.Services.Interfaces
{
    public interface IAuthStateService
    {
        bool IsUserAuthorized { get; set; }
        void SetUserAuthorized(bool isAuthorized);
    }
}
