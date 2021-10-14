using System.Text;

namespace RegisterSupervisorNotificationsLibrary.Models
{
    public class NotificationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Supervisor { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            sb.AppendLine($"Name: {FirstName} {LastName}");
            sb.AppendLine($"Contact: {this?.Phone ?? this.Email}");
            sb.AppendLine($"Supervisor: {this.Supervisor}");

            return sb.ToString();
        }
    }
}
