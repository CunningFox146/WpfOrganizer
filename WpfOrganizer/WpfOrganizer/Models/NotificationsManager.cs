using Notifications.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOrganizer.Models
{
    static class NotificationsManager
    {
        public static void ShowTaskWarning(string taskName, TimeSpan timeLeft)
        {
            int seconds = (int)(timeLeft.TotalSeconds);
            //Trace.WriteLine(seconds);
            if ((seconds == 60 * 60 && true) ||
                (seconds == 15 * 60 && true) ||
                (seconds == 5 * 60 && true) ||
                (seconds == 1 * 60 && true))
            {
                var notificationManager = new NotificationManager();

                notificationManager.ShowAsync(new NotificationContent
                {
                    Title = "Оповещение о задании",
                    Message = $"Задание {taskName} будет просрочено через {timeLeft.ToString(@"hh\:mm\:ss")}.",
                    Type = NotificationType.Warning
                });
            }
        }

        public static void ShowTaskExpired(string taskName)
        {
            if (true)
            {
                var notificationManager = new NotificationManager();

                notificationManager.ShowAsync(new NotificationContent
                {
                    Title = "Задание просрочено",
                    Message = $"Задание {taskName} было просрочено. Как жаль!",
                    Type = NotificationType.Error
                });
            }
        }
    }
}
