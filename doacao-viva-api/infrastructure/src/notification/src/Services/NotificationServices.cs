using DoacaoViva.Infrastructure.Notification.Entitys;
using DoacaoViva.Infrastructure.Notification.Enums;
using Microsoft.Extensions.Options;

namespace DoacaoViva.Infrastructure.Notification.Services;
public class NotificationServices : INotification {
    private readonly IOptions<NotificationSetings> _notificationSetings;
    public NotificationServices(IOptions<NotificationSetings> notificationSetings)
    {
        _notificationSetings = notificationSetings;
    }

    public Notifications SendNotification(string fromName, string fromEmailOrPhone, NotificationType notificationType) {
        var notification = new Notifications(fromName, fromEmailOrPhone, notificationType);
        if (notificationType == NotificationType.SMS) {
            notification.Message = _notificationSetings.Value.MensageBodySMS;
            notification.NotificationStatus = SMS.SendMessage(_notificationSetings.Value.MensageBodySMS, fromEmailOrPhone);
            //
        } else if (notificationType == NotificationType.Email) {
            notification.Message = _notificationSetings.Value.MensageBodyEmail;
            notification.NotificationStatus = Email.SendEmail(_notificationSetings.Value.MensageBodyEmail, fromEmailOrPhone);
            //
        } else {
            return new();
        }
        return notification;
    }
}

