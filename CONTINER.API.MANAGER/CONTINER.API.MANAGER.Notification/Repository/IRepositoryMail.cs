using CONTINER.API.MANAGER.Notification.Model;
using System.Collections.Generic;

namespace CONTINER.API.MANAGER.Notification.Repository
{
    public interface IRepositoryMail
    {
        IEnumerable<SendMail> GetAll();
        bool Add(SendMail sendMail);
    }
}
