namespace DevIO.Business.Notifications;

public class Notifier : INotifier
{
    private readonly List<Notification> _notifications;

    public Notifier() => _notifications = [];

    public bool HasNotification() => _notifications.Any();

    public List<Notification> GetNotifications() => _notifications;

    public void Handle(Notification notification) => _notifications.Add(notification);
}