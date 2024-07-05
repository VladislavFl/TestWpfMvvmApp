using System.Windows.Input;
using System.Windows;
using TestWpfMvvmApp.Utilities;
using TestWpfMvvmApp.Services.Interfaces;
using System.Windows.Controls;

namespace TestWpfMvvmApp.ViewModel
{
    internal class AuthViewModel : ViewModelBase
    {
        private string _login = string.Empty;
        private string _password = string.Empty;
        private bool _isUserAuthorized;
        private readonly IAuthStateService _authStateService;
        private readonly IUserService _userService;
        private readonly IDialogService _dialogService;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public bool IsUserAuthorized
        {
            get => _isUserAuthorized;
            set
            {
                _isUserAuthorized = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand => new RelayCommand(async param => await AuthMethod(param));
        public ICommand LogoutCommand => new RelayCommand(async param => await LogoutMethod());
        public ICommand RegisterWindowCommand => new RelayCommand(param => RegisterWindowMethod());

        private async Task AuthMethod(object param)
        {
            try
            {
                var passwordBox = param as PasswordBox;
                if (passwordBox == null) return;
                var password = passwordBox.Password;

                if (await _userService.LoginAsync(Login, password))
                {
                    _authStateService.SetUserAuthorized(true, Login);
                    if (_authStateService.IsUserAuthorized)
                    {
                        IsUserAuthorized = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LogoutMethod()
        {
            try
            {
                if (await _userService.LogoutAsync())
                {
                    _authStateService.SetUserAuthorized(false, string.Empty);
                    IsUserAuthorized = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RegisterWindowMethod()
        {
            var dialogViewModel = new RegisterViewModel(_userService, _authStateService);
            _dialogService.ShowDialog(dialogViewModel);
        }

        public AuthViewModel(IAuthStateService authStateService, IUserService userService, IDialogService dialogService)
        {
            _authStateService = authStateService;
            _userService = userService;
            _dialogService = dialogService;

            _authStateService.UserAuthorized += ShowAuthorizedView;
        }

        private void ShowAuthorizedView(object? sender, EventArgs e)
        {
            IsUserAuthorized = true;
        }
    }
}
