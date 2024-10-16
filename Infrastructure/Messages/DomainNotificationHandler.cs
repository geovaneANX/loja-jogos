using MediatR;

namespace Infrastructure.Messages
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private ICollection<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = [];
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public virtual IEnumerable<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return _notifications.Count != 0;
        }

        public void Dispose()
        {
            _notifications = [];
        }
    }
}