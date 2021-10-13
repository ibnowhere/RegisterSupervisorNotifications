namespace RegisterSupervisorNotificationsLibrary.Models
{
    public class Supervisor
    {
        public int Id { get; set; }
        public string Jurisdiction { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }

        public override string ToString()
        {
            return $"{Jurisdiction} - {LastName}, {FirstName}";
        }
    }
}
