﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterSupervisorNotifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public ApiController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Supervisors()
        {
            return new OkObjectResult(new { });
        }
    }
}
