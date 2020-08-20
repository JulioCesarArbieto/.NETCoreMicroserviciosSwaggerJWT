using CONTINER.API.MANAGER.Security.Model;
using Microsoft.EntityFrameworkCore;

namespace CONTINER.API.MANAGER.Security.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Access> Access { get; set; }
    }
}
