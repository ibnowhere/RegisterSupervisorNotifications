using System.Text.Json.Serialization;

namespace RegisterSupervisorNotificationsLibrary.Models
{
    public class Supervisor
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("jurisdiction")]
        public string Jurisdiction { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("identificationNumber")]
        public string IdentificationNumber { get; set; }

        public override string ToString()
        {
            return $"{Jurisdiction} - {LastName}, {FirstName}";
        }
    }
}
