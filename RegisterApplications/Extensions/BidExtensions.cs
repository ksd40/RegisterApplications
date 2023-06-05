using RegisterApplications.Models;
using RegisterApplications.ViewModels;

namespace RegisterApplications.Extensions
{
    public static class BidExtensions
    {
        public static BidViewModel ToViewModel(this Bid bid)
        {
            return new BidViewModel()
            {
                Id = bid.Id,
                Name= bid.Name,
                Sender = bid.Sender,
                Recipient = bid.Recipient,
                Comment = bid.Comment,
                Status = bid.Status,
                Cargo = bid.Cargo,
                CourierId = bid.CourierId,
                Courier= bid.Courier,  
            };
        }

        public static Bid ToBid(this BidViewModel bid)
        {
            return new Bid()
            {
                Id = bid.Id,
                Name = bid.Name,
                Sender = bid.Sender,
                Recipient = bid.Recipient,
                Comment = bid.Comment,
                Status = bid.Status,
                Cargo = bid.Cargo,
                CourierId = bid.CourierId,
                Courier = bid.Courier,
            };
        }
    }
}
