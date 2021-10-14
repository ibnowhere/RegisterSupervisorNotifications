namespace RegisterSupervisorNotificationsLibrary.Services.Interfaces
{
    public interface IUnitOfWork
    {
        public INotificationSubscriptionRepo SubscriptionRepo { get;}
        public ISupervisorRepo SupervisorRepo { get; }
    }
}
