namespace TestWpfMvvmApp.Services.Interfaces
{
    public interface IDialogService
    {
        bool? ShowDialog<T>(T viewModel);
    }
}
