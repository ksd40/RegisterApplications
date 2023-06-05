using RegisterApplications.Models;

namespace RegisterApplications.ViewModels
{
    public class BidViewModel : ViewModel
    {
        private string _name;
        private string _sender;
        private string _recipient;
        private string _cargo;
        private string _comment;
        private Status _status;
        private Courier _courier;

        public int Id { get; set; }
        public int? CourierId { get; set; }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        public string Sender
        {
            get => _sender;
            set => Set(ref _sender, value);
        }
        public string Recipient
        {
            get => _recipient;
            set => Set(ref _recipient, value);
        }
        public string Cargo
        {
            get => _cargo;
            set => Set(ref _cargo, value);
        }
        public string? Comment
        {
            get => _comment;
            set => Set(ref _comment, value);
        }
        public Status Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        public Courier Courier 
        {
            get => _courier; 
            set => Set(ref _courier, value); 
        }
    }
}
