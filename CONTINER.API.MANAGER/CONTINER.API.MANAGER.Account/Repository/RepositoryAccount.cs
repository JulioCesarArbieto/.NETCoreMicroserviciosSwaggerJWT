using CONTINER.API.MANAGER.Account.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CONTINER.API.MANAGER.Account.Repository
{
    public class RepositoryAccount : IRepositoryAccount
    {
        private readonly IContextDatabase _context;
        public RepositoryAccount(IContextDatabase context)
        {
            _context = context;
        }

        public bool Deposit(Model.Account account)
        {
            _context.Account.Update(account);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Model.Account> GetAll()
        {
            return _context.Account.AsNoTracking<Model.Account>().Include(x => x.Customer).ToList();
        }

        public bool Withdrawal(Model.Account account)
        {
            _context.Account.Update(account);
            _context.SaveChanges();
            return true;
        }
    }
}
