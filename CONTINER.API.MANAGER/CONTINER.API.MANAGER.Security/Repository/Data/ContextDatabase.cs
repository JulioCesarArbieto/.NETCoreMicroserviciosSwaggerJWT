using CONTINER.API.MANAGER.Security.Model;
using Microsoft.EntityFrameworkCore;

namespace CONTINER.API.MANAGER.Security.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Access> Access { get; set; }
        public DbContext Instance => this;

    }
}
