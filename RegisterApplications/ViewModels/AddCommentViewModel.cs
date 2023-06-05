using RegisterApplications.Commands;
using System.Windows;
using System.Windows.Input;

namespace RegisterApplications.ViewModels
{
    public class AddCommentViewModel
    {
        public ICommand CloseWindowCommand { get; }
        public string Comment { get; set; }

        public AddCommentViewModel()
        {
            CloseWindowCommand = new LambdaCommand(CloseWindow, CanCloseWindow);
        }

        private bool CanCloseWindow(object? p)
        {
            return !string.IsNullOrEmpty(Comment);
        }
        private void CloseWindow(object? p)
        {
            Window window = p as Window;
            window.DialogResult = true;
            window.Close();
        }
    }
}
