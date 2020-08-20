using CONTINER.API.MANAGER.Notification.Model;
using System.Collections.Generic;

namespace CONTINER.API.MANAGER.Notification.Service
{
    public interface IServiceMail
    {
        IEnumerable<SendMail> GetAll();
        bool Add(SendMail sendMail);
    }
}
