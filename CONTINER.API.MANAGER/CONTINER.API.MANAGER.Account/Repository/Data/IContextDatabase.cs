using Microsoft.EntityFrameworkCore;

namespace CONTINER.API.MANAGER.Account.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Model.Account> Account { get; set; }
        DbSet<Model.Customer> Customer { get; set; }
        int SaveChanges();
    }
}
