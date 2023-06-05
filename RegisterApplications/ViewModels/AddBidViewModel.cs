using System.Windows.Input;
using System.Windows;
using RegisterApplications.Commands;

namespace RegisterApplications.ViewModels
{
    public class AddBidViewModel : ViewModel
    {
        public string Name { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Cargo { get; set; }
        public ICommand CloseWindowCommand { get; }

        public AddBidViewModel()
        {
            Name =string.Empty;
            Sender = string.Empty;
            Recipient = string.Empty;
            Cargo = string.Empty;

            CloseWindowCommand = new LambdaCommand(CloseWindow, CanCloseWindow);
        }

        public BidViewModel CreateBid()
        {
            return new BidViewModel
                {
                    Name = Name,
                    Sender = Sender,
                    Recipient = Recipient,
                    Cargo = Cargo
                };
        }

        private bool CanCloseWindow(object? p)
        {
            if (string.IsNullOrEmpty(Name))
                return false;
            if (string.IsNullOrEmpty(Sender))
                return false;
            if (string.IsNullOrEmpty(Recipient))
                return false;
            if (string.IsNullOrEmpty(Cargo))
                return false;
            return true;
        }
        private void CloseWindow(object? p)
        {
            Window window = p as Window;
            window.DialogResult = true;
            window.Close();
        }
    }
}
