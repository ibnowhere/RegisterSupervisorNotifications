using RegisterSupervisorNotificationsLibrary.Services.Interfaces;
using System;

namespace RegisterSupervisorNotificationsLibrary.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public INotificationSubscriptionRepo SubscriptionRepo { get; }
        public ISupervisorRepo SupervisorRepo { get; }

        public UnitOfWork(INotificationSubscriptionRepo subscriptionRepo, ISupervisorRepo supervisorRepo)
        {
            SubscriptionRepo = subscriptionRepo ?? throw new ArgumentNullException(nameof(subscriptionRepo));
            SupervisorRepo = supervisorRepo ?? throw new ArgumentNullException(nameof(supervisorRepo));
        }
    }
}
