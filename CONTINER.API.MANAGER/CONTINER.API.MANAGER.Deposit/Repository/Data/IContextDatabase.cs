using CONTINER.API.MANAGER.Deposit.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Deposit.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Transaction> Transaction { get; set; }
        int SaveChanges();
    }
}
