using CONTINER.API.MANAGER.Deposit.Model;
using Microsoft.EntityFrameworkCore;

namespace CONTINER.API.MANAGER.Deposit.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();
        }

        public DbContext Instance => this;

        public DbSet<Transaction> Transaction { get; set; }
    }
}
