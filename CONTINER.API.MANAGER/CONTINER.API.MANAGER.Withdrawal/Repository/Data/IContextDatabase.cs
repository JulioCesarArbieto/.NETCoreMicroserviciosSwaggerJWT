using CONTINER.API.MANAGER.Withdrawal.Model;
using Microsoft.EntityFrameworkCore;

namespace CONTINER.API.MANAGER.Withdrawal.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Transaction> Transaction { get; set; }
        int SaveChanges();
    }
}
