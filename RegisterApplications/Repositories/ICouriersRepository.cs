using RegisterApplications.Models;
using System.Collections.Generic;

namespace RegisterApplications.Repositories
{
    public interface ICouriersRepository
    {
        List<Courier> GetAll();
    }
}
