using CONTINER.API.MANAGER.Withdrawal.Model;

namespace CONTINER.API.MANAGER.Withdrawal.Repository
{
    public interface IRepositoryTransaction
    {
        Transaction Withdrawal(Transaction transaction);
        Transaction WithdrawalReverse(Transaction transaction);
    }
}
