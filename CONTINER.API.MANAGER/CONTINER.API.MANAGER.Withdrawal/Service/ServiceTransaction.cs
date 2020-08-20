
using CONTINER.API.MANAGER.Withdrawal.Model;
using CONTINER.API.MANAGER.Withdrawal.Repository;

namespace CONTINER.API.MANAGER.Withdrawal.Service
{
    public class ServiceTransaction : IServiceTransaction
    {
        private readonly IRepositoryTransaction _repositoryTransaction;
        public ServiceTransaction(IRepositoryTransaction repositoryTransaction)
        {
            _repositoryTransaction = repositoryTransaction;
        }

        public Transaction Withdrawal(Transaction transaction)
        {
            return _repositoryTransaction.Withdrawal(transaction);
        }

        public Transaction WithdrawalReverse(Transaction transaction)
        {
            return _repositoryTransaction.WithdrawalReverse(transaction);
        }
    }
}
