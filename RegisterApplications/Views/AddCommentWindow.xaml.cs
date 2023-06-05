using RegisterApplications.ViewModels;
using System.Windows;

namespace RegisterApplications.Views
{
    public partial class AddCommentWindow : Window
    {
        public AddCommentWindow(AddCommentViewModel addCommentViewModel)
        {
            InitializeComponent();
            DataContext = addCommentViewModel;
        }
    }
}
