using System.Windows.Input;
using TestWpfMvvmApp.Services.Interfaces;
using TestWpfMvvmApp.Utilities;

namespace TestWpfMvvmApp.ViewModel
{
    internal class NavigationViewModel : ViewModelBase
    {
        private object? _authView;
        private object? _currentView;
        private readonly IAuthStateService _authStateService;
        private readonly IUserService _userService;
        private readonly IDialogService _dialogService;

        public object? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public object? AuthView
        {
            get => _authView;
            set { _authView = value; OnPropertyChanged(); }
        }

        public ICommand UserCommand { get; set; }
        public ICommand InfoCommand { get; set; }
        public ICommand GuestCommand { get; set; }

        private void User(object obj)
        {
            if (_authStateService.IsUserAuthorized)
            {
                CurrentView = new UserViewModel(_userService, _authStateService);
            }
            else
            {
                CurrentView = new GuestViewModel();
            }
        }

        private void Info(object obj) => CurrentView = new InfoViewModel();
        private void Guest(object obj) => CurrentView = new GuestViewModel();

        public NavigationViewModel(IAuthStateService authStateService, IUserService userService, IDialogService dialogService)
        {
            UserCommand = new RelayCommand(User);
            InfoCommand = new RelayCommand(Info);
            GuestCommand = new RelayCommand(Guest);

            CurrentView = new GuestViewModel();
            AuthView = new AuthViewModel(authStateService, userService, dialogService);
            _authStateService = authStateService;
            _userService = userService;
            _dialogService = dialogService;

            _authStateService.UserAuthorized += ShowAuthorizedView;
            _authStateService.UserNonAuthorized += ShowGuestView;
        }

        private void ShowAuthorizedView(object? sender, EventArgs e)
        {
            CurrentView = new UserViewModel(_userService, _authStateService);
        }

        private void ShowGuestView(object? sender, EventArgs e)
        {
            CurrentView = new GuestViewModel();
        }
    }
}
