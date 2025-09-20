using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Services
{
    public interface INotificationService
    {
        void RegisterProvider(INotificationProvider provider);
        Task Notify(NotificationMessage notificationMessage);
    }
}
