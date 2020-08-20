using CONTINER.API.MANAGER.Account.Repository;
using System.Collections.Generic;

namespace CONTINER.API.MANAGER.Account.Service
{
    public class ServiceAccount : IServiceAccount
    {
        private readonly IRepositoryAccount _accountRepository;

        public ServiceAccount(IRepositoryAccount accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool Deposit(Model.Account account)
        {
            return _accountRepository.Deposit(account);
        }

        public IEnumerable<Model.Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public bool Withdrawal(Model.Account account)
        {
            return _accountRepository.Withdrawal(account);
        }
    }
}
