using System.Collections.Generic;

namespace CONTINER.API.MANAGER.Account.Service
{
    public interface IServiceAccount
    {
        IEnumerable<Model.Account> GetAll();
        bool Deposit(Model.Account account);
        bool Withdrawal(Model.Account account);
    }
}
