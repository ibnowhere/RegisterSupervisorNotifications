using RegisterSupervisorNotificationsLibrary.Models;
using RegisterSupervisorNotificationsLibrary.Services.Interfaces;
using System;

namespace RegisterSupervisorNotificationsLibrary.Services
{
    public class NotificationSubscriptionRepo : INotificationSubscriptionRepo
    {
        public NotificationSubscriptionRepo()
        {

        }

        public void Submit(NotificationRequest notificationRequest)
        {
            if (notificationRequest is null)
            {
                throw new ArgumentNullException(nameof(notificationRequest));
            }

            Console.WriteLine(notificationRequest.ToString());
        }
    }
}
