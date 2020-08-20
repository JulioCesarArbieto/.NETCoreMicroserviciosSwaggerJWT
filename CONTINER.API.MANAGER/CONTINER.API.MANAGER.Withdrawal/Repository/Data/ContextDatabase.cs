using CONTINER.API.MANAGER.Withdrawal.Model;
using Microsoft.EntityFrameworkCore;

namespace CONTINER.API.MANAGER.Withdrawal.Repository.Data
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
