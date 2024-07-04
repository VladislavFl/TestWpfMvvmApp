namespace TestWpfMvvmApp.ViewModel
{
    internal class InfoViewModel : Utilities.ViewModelBase
    {
        private string _devInfo = "Разработчик: VladislavFl\nGitHub: https://github.com/VladislavFl";
        public string DevInfo
        {
            get => _devInfo;
            set
            {
                _devInfo = value;
                OnPropertyChanged();
            }
        }
    }
}
