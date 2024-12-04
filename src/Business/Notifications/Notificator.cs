using Hamurgueria.Business.Intefaces.ServicesIntefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Notifications
{
    public class Notificator : INotificator
    {
        public Notificator()
        {
            _notifications = new List<Notification>();
        }
        private List<Notification> _notifications;
        public void Handle(Notification notificacao)
        {
            _notifications.Add(notificacao);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
