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
        private static NotificationManager notificationManager = new NotificationManager();

        public static void ShowTaskWarning(string taskName, TimeSpan timeLeft)
        {
            int seconds = (int)(timeLeft.TotalSeconds);
            //Trace.WriteLine(seconds);

            if ((seconds == 60 * 60 && AppSettings.NotifyOn60) ||
                (seconds == 15 * 60 && AppSettings.NotifyOn15) ||
                (seconds == 5 * 60 && AppSettings.NotifyOn5) ||
                (seconds == 1 * 60 && AppSettings.NotifyOn1))
            {
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
            if (AppSettings.NotifyOnExpired)
            {
                notificationManager.ShowAsync(new NotificationContent
                {
                    Title = "Задание просрочено",
                    Message = $"Задание {taskName} было просрочено. Как жаль!",
                    Type = NotificationType.Error
                });
            }
        }

        public static void NotifyDuplicateName()
        {
            notificationManager.ShowAsync(new NotificationContent
            {
                Title = "Ошибка регистрации",
                Message = $"Пользователь с таким именем уже зарегистрирован.",
                Type = NotificationType.Error
            });
        }

        public static void NotifyWrongLoginInfo()
        {
            notificationManager.ShowAsync(new NotificationContent
            {
                Title = "Ошибка входа",
                Message = $"Введено неверное имя или пароль.",
                Type = NotificationType.Error
            });
        }

        public static void NotifyPasswordsDontMatch()
        {
            notificationManager.ShowAsync(new NotificationContent
            {
                Title = "Ошибка паролей",
                Message = $"Введенные пароли не совпадают.",
                Type = NotificationType.Error
            });
        }

        public static void NotifyNameChangeFailed()
        {
            notificationManager.ShowAsync(new NotificationContent
            {
                Title = "Ошибка смены имени",
                Message = $"Введенное имя уже используется в системе.",
                Type = NotificationType.Error
            });
        }

        public static void NotifyNameChanged(string name)
        {
            notificationManager.ShowAsync(new NotificationContent
            {
                Title = "Имя изменено",
                Message = $"Ваше имя было сменено на {name}.",
                Type = NotificationType.Success
            });
        }

        public static void NotifyAvatarChanged()
        {
            notificationManager.ShowAsync(new NotificationContent
            {
                Title = "Аватар был изменен",
                Message = $"Выглядит круто, кстати.",
                Type = NotificationType.Success
            });
        }

        public static void NotifyPasswordChangeFailed()
        {
            notificationManager.ShowAsync(new NotificationContent
            {
                Title = "Пароль не изменен",
                Message = $"Пароль не изменен. Вы ввели неверные даные.",
                Type = NotificationType.Error
            });
        }

        public static void NotifyPasswordChanged()
        {
            notificationManager.ShowAsync(new NotificationContent
            {
                Title = "Пароль изменен",
                Message = $"Ваш пароль быз изменен. Надеюсь вы его где-то записали.",
                Type = NotificationType.Success
            });
        }
    }
}
