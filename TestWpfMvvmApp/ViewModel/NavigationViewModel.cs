using System.Windows.Input;
using TestWpfMvvmApp.Services.Interfaces;
using TestWpfMvvmApp.Utilities;

namespace TestWpfMvvmApp.ViewModel
{
    internal class NavigationViewModel : ViewModelBase
    {
        private object? _authView;
        private object? _currentView;
        private bool _isUserAuthorized;
        private readonly IAuthStateService _authStateService;


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

        public bool IsUserAuthorized
        {
            get => _isUserAuthorized;
            set { _isUserAuthorized = value; OnPropertyChanged(); }
        }

        public ICommand UserCommand { get; set; }
        public ICommand InfoCommand { get; set; }
        public ICommand GuestCommand { get; set; }

        private void User(object obj)
        {
            if (_authStateService.IsUserAuthorized)
            {
                CurrentView = new UserViewModel();
            }
            else
            {
                CurrentView = new GuestViewModel();
            }
        }

        private void Info(object obj) => CurrentView = new InfoViewModel();
        private void Guest(object obj) => CurrentView = new GuestViewModel();

        public NavigationViewModel(IAuthStateService authStateService)
        {
            UserCommand = new RelayCommand(User);
            InfoCommand = new RelayCommand(Info);
            GuestCommand = new RelayCommand(Guest);

            CurrentView = new GuestViewModel();
            AuthView = new AuthViewModel(authStateService);
            _authStateService = authStateService;
        }
    }
}
