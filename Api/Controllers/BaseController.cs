using Infrastructure.Messages.Interfaces;
using Infrastructure.Messages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public abstract class BaseController<T> : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMessagesHandler _messagesHandler;

        protected BaseController(INotificationHandler<DomainNotification> notifications,
                                 IMessagesHandler messagesHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _messagesHandler = messagesHandler;
        }

        protected bool IsValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected IEnumerable<string> GetErrorMessages()
        {
            return _notifications.GetNotifications().Select(notification => notification.Value).ToList();
        }

        protected void NotifyError(string code, string message)
        {
            _messagesHandler.SendDomainNotificationAsync(new DomainNotification(code, message));
        }
    }
}