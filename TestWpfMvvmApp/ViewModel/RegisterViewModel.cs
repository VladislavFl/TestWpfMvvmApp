using System.Windows.Input;
using TestWpfMvvmApp.Model;
using TestWpfMvvmApp.Services.Interfaces;
using TestWpfMvvmApp.Utilities;
using System.Windows;
using TestWpfMvvmApp.Services;

namespace TestWpfMvvmApp.ViewModel
{
    internal class RegisterViewModel : ViewModelBase
    {
        private User _user = new User();
        private readonly IUserService _userService;
        private readonly IAuthStateService _authStateService;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public ICommand RegisterCommand => new RelayCommand(async param => await RegisterMethod(param));

        public RegisterViewModel(IUserService userService, IAuthStateService authStateService)
        {
            _userService = userService;
            _authStateService = authStateService;
        }

        private async Task RegisterMethod(object param)
        {
            try
            {
                var dialogWindow = param as Window;
                if (await _userService.RegisterAsync(User))
                {
                    dialogWindow!.Close();
                    if (await _userService.LoginAsync(User.Username, User.Password))
                    {
                        _authStateService.SetUserAuthorized(true, User.Username);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
