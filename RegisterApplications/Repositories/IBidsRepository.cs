using RegisterApplications.Models;
using System.Collections.Generic;

namespace RegisterApplications.Repositories
{
    public interface IBidsRepository 
    {
        List<Bid> GetAll();
        Bid Add(Bid bid);
        void Update(Bid bid);
        void Delete(Bid bid);
    }
}
