using Microsoft.EntityFrameworkCore;

namespace CONTINER.API.MANAGER.Account.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Model.Account> Account { get; set; }
        public DbSet<Model.Customer> Customer { get; set; }
        public DbContext Instance => this;
    }
}
