using CONTINER.API.MANAGER.Withdrawal.Model;

namespace CONTINER.API.MANAGER.Withdrawal.Service
{
    public interface IServiceTransaction
    {
        Transaction Withdrawal(Transaction transaction);
        Transaction WithdrawalReverse(Transaction transaction);
    }
}
