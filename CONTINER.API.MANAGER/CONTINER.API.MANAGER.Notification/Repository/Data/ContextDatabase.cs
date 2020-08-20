using CONTINER.API.MANAGER.Notification.Model;
using Microsoft.EntityFrameworkCore;

namespace CONTINER.API.MANAGER.Notification.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase
            (DbContextOptions<ContextDatabase> options) : base(options)
        {
        }
        public DbContext Instance => this;

        public DbSet<SendMail> SendMail { get; set; }
    }
}
