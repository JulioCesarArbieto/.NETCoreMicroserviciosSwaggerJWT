using System.Collections.Generic;

namespace CONTINER.API.MANAGER.Account.Repository
{
    public interface IRepositoryAccount
    {
        IEnumerable<Model.Account> GetAll();
        bool Deposit(Model.Account account);
        bool Withdrawal(Model.Account account);
    }
}
