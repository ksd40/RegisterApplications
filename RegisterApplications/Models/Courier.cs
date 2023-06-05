using System.Collections.Generic;

namespace RegisterApplications.Models
{
    public class Courier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Bid> Bids { get; set; }
    }
}
