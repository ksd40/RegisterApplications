using RegisterApplications.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegisterApplications.Repositories
{
    internal class CouriersRepository : ICouriersRepository
    {
        public List<Courier> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Couriers.ToList();
            }
        }
    }
}
