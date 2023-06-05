using RegisterApplications.Commands;
using System.Windows;
using System.Windows.Input;

namespace RegisterApplications.ViewModels
{
    public class EditBidViewModel : ViewModel
    {
        public BidViewModel Bid { get; set; }
        public ICommand CloseWindowCommand { get; }

        public EditBidViewModel(BidViewModel selectedBid)
        {
            Bid = selectedBid;

            CloseWindowCommand = new LambdaCommand(CloseWindow, CanCloseWindow);
        }

        private bool CanCloseWindow(object? p)
        {
            if (string.IsNullOrEmpty(Bid.Name))
                return false;
            if (string.IsNullOrEmpty(Bid.Sender))
                return false;
            if (string.IsNullOrEmpty(Bid.Recipient))
                return false;
            if (string.IsNullOrEmpty(Bid.Cargo))
                return false;
            return true;
        }
        private void CloseWindow(object? p)
        {
            Window window = p as Window;
            window.DialogResult= true;
            window.Close();
        }

    }
}
