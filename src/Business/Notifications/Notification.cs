using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamurgueria.Business.Notifications
{
    public class Notification
    {
        public Notification(string message)
        {
            Mensage = message;
        }
        public string Mensage { get; set; }
        
    }
}
