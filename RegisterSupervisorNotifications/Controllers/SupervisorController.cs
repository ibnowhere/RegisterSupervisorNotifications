using Microsoft.AspNetCore.Mvc;
using RegisterSupervisorNotificationsLibrary.Models;
using RegisterSupervisorNotificationsLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterSupervisorNotifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupervisorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            try
            {
                List<Supervisor> supervisors = (await _unitOfWork.SupervisorRepo.GetSupervisors()).ToList();
                return supervisors.OrderBy(s => s.Jurisdiction).ThenBy(s => s.LastName).ThenBy(s => s.FirstName).Select(s => s.ToString());
            }
            catch (Exception)
            {
                return Enumerable.Empty<string>();
            }
        }
    }
}
