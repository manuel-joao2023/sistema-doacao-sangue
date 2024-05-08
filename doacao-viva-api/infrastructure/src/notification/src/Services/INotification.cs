
using DoacaoViva.Infrastructure.Notification.Entitys;
using DoacaoViva.Infrastructure.Notification.Enums;

namespace DoacaoViva.Infrastructure.Notification.Services;
public interface INotification {
    Notifications SendNotification(string FromName, string FromEmailOrPhone, NotificationType NotificationType);
}

