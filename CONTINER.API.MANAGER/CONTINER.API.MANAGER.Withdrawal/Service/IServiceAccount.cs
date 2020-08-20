using CONTINER.API.MANAGER.Withdrawal.DTO;
using CONTINER.API.MANAGER.Withdrawal.Model;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Withdrawal.Service
{
    public interface IServiceAccount
    {
        Task<bool> WithdrawalAccount(AccountRequest request);
        bool WithdrawalReverse(Transaction request);
        bool Execute(Transaction request);
    }
}
