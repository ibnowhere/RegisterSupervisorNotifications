using RegisterSupervisorNotificationsLibrary.Models;

namespace RegisterSupervisorNotificationsLibrary.Services.Interfaces
{
    public interface INotificationSubscriptionRepo
    {
        public void Submit(NotificationRequest notificationRequest);
    }
}
