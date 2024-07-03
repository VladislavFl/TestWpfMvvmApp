using System.Windows.Input;
using TestWpfMvvmApp.Utilities;

namespace TestWpfMvvmApp.ViewModel
{
    internal class NavigationViewModel : ViewModelBase
    {
        private object? _currentView;
        public object? CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand UserCommand { get; set; }
        public ICommand InfoCommand { get; set; }

        private void User(object obj) => CurrentView = new UserViewModel();
        private void Info(object obj) => CurrentView = new InfoViewModel();

        public NavigationViewModel()
        {
            UserCommand = new RelayCommand(User);
            InfoCommand = new RelayCommand(Info);

            CurrentView = new UserViewModel();
        }
    }
}
