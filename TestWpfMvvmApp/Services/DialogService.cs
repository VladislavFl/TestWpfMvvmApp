using TestWpfMvvmApp.Services.Interfaces;

namespace TestWpfMvvmApp.Services
{
    public class DialogService : IDialogService
    {
        public bool? ShowDialog<T>(T viewModel)
        {
            var dialog = new RegisterWindow();
            dialog.DataContext = viewModel;

            return dialog.ShowDialog();
        }
    }
}
