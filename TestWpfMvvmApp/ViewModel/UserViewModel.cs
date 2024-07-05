using TestWpfMvvmApp.Services.Interfaces;
using System.Windows;

namespace TestWpfMvvmApp.ViewModel
{
    internal class UserViewModel : Utilities.ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly IAuthStateService _authStateService;
        private string _id = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _phone = string.Empty;

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel(IUserService userService, IAuthStateService authStateService)
        {
            _userService = userService;
            _authStateService = authStateService;
            LoadUserData();
        }

        private async void LoadUserData()
        {
            try
            {
                var user = await _userService.GetUserDataAsync(_authStateService.Username);
                Id = user.Id.ToString();
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
                Phone = user.Phone;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
