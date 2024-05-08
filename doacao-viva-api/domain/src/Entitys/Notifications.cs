using DoacaoViva.Domain.Entitys;
using DoacaoViva.Infrastructure.Notification.Enums;
namespace DoacaoViva.Infrastructure.Notification.Entitys;
public class Notifications : BaseEntity {
    public string? Message { get; set; }
    public string? FromName { get; set; }
    public string? FromEmailOrPhone { get; set; }
    public NotificationType? NotificationType { get; set; }
    public string? NotificationStatus { get; set; }
    public Notifications()
    {
        
    }
    public Notifications(string? fromName, string? fromEmailOrPhone, NotificationType notificationType ) {
        FromName = fromName;
        FromEmailOrPhone = fromEmailOrPhone;
        NotificationType = notificationType;
    }
}

