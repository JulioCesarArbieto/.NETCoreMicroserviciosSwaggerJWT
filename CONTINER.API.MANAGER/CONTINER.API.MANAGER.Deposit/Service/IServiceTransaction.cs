using CONTINER.API.MANAGER.Deposit.Model;

namespace CONTINER.API.MANAGER.Deposit.Service
{
    public interface IServiceTransaction
    {
        Transaction Deposit(Transaction transaction);
        Transaction DepositReverse(Transaction transaction);
    }
}
