using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterSupervisorNotificationsLibrary.Models;
using RegisterSupervisorNotificationsLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegisterSupervisorNotifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        public async Task<IActionResult> Supervisors()
        {
            try
            {
                List<Supervisor> supervisors = (await _unitOfWork.SupervisorRepo.GetSupervisors()).ToList();
                return new OkObjectResult(supervisors.OrderBy(s => s.Jurisdiction).ThenBy(s => s.LastName).ThenBy(s => s.FirstName).Select(s => s.ToString()));
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpPost]
        public IActionResult Submit(NotificationRequest notificationRequest)
        {
            if (notificationRequest is null)
            {
                return new BadRequestResult();
            }

            IEnumerable<string> errors = ValidateNotificationRequest(notificationRequest);

            if (errors.Any())
            {
                return new BadRequestObjectResult(errors);
            }

            try
            {
                _unitOfWork.SubscriptionRepo.Submit(notificationRequest);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }

            return CreatedAtAction(nameof(notificationRequest), new { supervisor = notificationRequest.Supervisor }, notificationRequest);
        }

        private IEnumerable<string> ValidateNotificationRequest(NotificationRequest notificationRequest)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(notificationRequest.FirstName))
            {
                errors.Add("Please provide First Name");
            }

            if (string.IsNullOrWhiteSpace(notificationRequest.LastName))
            {
                errors.Add("Please provide Last Name");
            }

            if (string.IsNullOrWhiteSpace(notificationRequest.Phone) && string.IsNullOrWhiteSpace(notificationRequest.Email))
            {
                errors.Add("Please provide preferred contact information");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(notificationRequest.Email) && !ValidateEmail(notificationRequest.Email))
                {
                    errors.Add("Invalid email format");
                }
                else if(string.IsNullOrWhiteSpace(notificationRequest.Phone) && !ValidatePhone(notificationRequest.Phone))
                {
                    errors.Add("Invalid phone format");
                }
            }

            if (string.IsNullOrWhiteSpace(notificationRequest.Supervisor))
            {
                errors.Add("Please select supervisor");
            }

            return errors;
        }
        private bool ValidatePhone(string phoneNumber)
        {
            try
            {
                return Regex.Match(phoneNumber, @"^(\+[0-9]{9})$").Success;
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

        }
    }
}
