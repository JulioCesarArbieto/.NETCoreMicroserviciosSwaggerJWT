using CONTINER.API.MANAGER.Deposit.Model;
using CONTINER.API.MANAGER.Deposit.Repository;

namespace CONTINER.API.MANAGER.Deposit.Service
{
    public class ServiceTransaction : IServiceTransaction
    {
        private readonly IRepositoryTransaction _repositoryTransaction;
        public ServiceTransaction(IRepositoryTransaction repositoryTransaction)
        {
            _repositoryTransaction = repositoryTransaction;
        }

        public Transaction Deposit(Transaction transaction)
        {
            return _repositoryTransaction.Deposit(transaction);
        }

        public Transaction DepositReverse(Transaction transaction)
        {
            return _repositoryTransaction.DepositReverse(transaction);
        }
    }
}
