using RegisterApplications.ViewModels;
using System.Windows;

namespace RegisterApplications.Views
{
    public partial class ChoiceCourierWindow : Window
    {
        public ChoiceCourierWindow(ChoiceCourierViewModel choiceCourierViewModel)
        {
            InitializeComponent();
            DataContext = choiceCourierViewModel;
        }
    }
}
