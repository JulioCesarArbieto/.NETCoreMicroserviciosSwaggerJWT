using CONTINER.API.MANAGER.Deposit.Model;

namespace CONTINER.API.MANAGER.Deposit.Repository
{
    public interface IRepositoryTransaction
    {
        Transaction Deposit(Transaction transaction);
        Transaction DepositReverse(Transaction transaction);
    }
}
