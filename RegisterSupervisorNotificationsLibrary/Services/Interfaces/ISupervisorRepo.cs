using RegisterSupervisorNotificationsLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterSupervisorNotificationsLibrary.Services.Interfaces
{
    public interface ISupervisorRepo
    {
        public Task<IEnumerable<Supervisor>> GetSupervisors();
    }
}
