using Microsoft.EntityFrameworkCore;
using RegisterApplications.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegisterApplications.Repositories
{
    internal class BidsRepository : IBidsRepository
    {
        public Bid Add(Bid bid)
        {
            using (var db = new ApplicationContext())
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return bid;
            }       
        }

        public void Delete(Bid bid)
        {
            using (var db = new ApplicationContext())
            {
                db.Bids.Remove(bid);
                db.SaveChanges();
            }
        }

        public List<Bid> GetAll()
        {
            using (var db = new ApplicationContext())
            {
                return db.Bids.Include(b => b.Courier).ToList();
            }
        }

        public void Update(Bid bid)
        {
            using (var db = new ApplicationContext())
            {
                db.Entry(bid).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
