using RegisterApplications.ViewModels;

namespace RegisterApplications.Models
{
    public class Bid : ViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Cargo { get; set; }
        public string? Comment { get; set; }
        public Status Status { get; set; }
        public int? CourierId { get; set; }
        public Courier Courier { get; set; }
    }
}
