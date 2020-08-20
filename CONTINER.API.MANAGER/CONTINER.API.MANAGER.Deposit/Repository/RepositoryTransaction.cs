using CONTINER.API.MANAGER.Deposit.Model;
using CONTINER.API.MANAGER.Deposit.Repository.Data;

namespace CONTINER.API.MANAGER.Deposit.Repository
{
    public class RepositoryTransaction : IRepositoryTransaction
    {
        private readonly IContextDatabase _context;
        public RepositoryTransaction(IContextDatabase context)
        {
            _context = context;
        }

        public Transaction Deposit(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }

        public Transaction DepositReverse(Transaction transaction)
        {
            _context.Transaction.AddAsync(transaction);
            _context.SaveChanges();
            return transaction;
        }
    }
}
