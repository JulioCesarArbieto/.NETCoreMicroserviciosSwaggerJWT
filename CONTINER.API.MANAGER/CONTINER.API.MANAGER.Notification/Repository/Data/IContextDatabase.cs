using CONTINER.API.MANAGER.Notification.Model;
using Microsoft.EntityFrameworkCore;

namespace CONTINER.API.MANAGER.Notification.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<SendMail> SendMail { get; set; }
        int SaveChanges();
    }
}
