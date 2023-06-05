using RegisterApplications.ViewModels;
using System.Windows;

namespace RegisterApplications.Views
{
    public partial class EditBidWindow : Window
    {
        public EditBidWindow(EditBidViewModel editBidViewModel)
        {
            InitializeComponent();
            DataContext = editBidViewModel;
        }
    }
}
