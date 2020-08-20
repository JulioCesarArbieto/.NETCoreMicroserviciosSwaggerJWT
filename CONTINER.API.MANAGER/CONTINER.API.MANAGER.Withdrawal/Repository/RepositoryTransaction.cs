using CONTINER.API.MANAGER.Withdrawal.Model;
using CONTINER.API.MANAGER.Withdrawal.Repository.Data;

namespace CONTINER.API.MANAGER.Withdrawal.Repository
{
    public class RepositoryTransaction : IRepositoryTransaction
    {
        private readonly IContextDatabase _context;
        public RepositoryTransaction(IContextDatabase context)
        {
            _context = context;
        }

        public Transaction Withdrawal(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            return transaction;

        }

        public Transaction WithdrawalReverse(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }
    }
}
