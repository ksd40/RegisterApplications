using RegisterApplications.ViewModels;
using System.Windows;

namespace RegisterApplications.Views
{
    public partial class AddBidWindow : Window
    {
        public AddBidWindow(AddBidViewModel addBidViewModel)
        {
            InitializeComponent();
            DataContext = addBidViewModel;
        }
    }
}
