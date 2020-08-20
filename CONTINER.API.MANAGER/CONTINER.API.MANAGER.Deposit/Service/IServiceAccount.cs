using CONTINER.API.MANAGER.Deposit.DTO;
using CONTINER.API.MANAGER.Deposit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Deposit.Service
{
    public interface IServiceAccount
    {
        Task<bool> DepositAccount(AccountRequest request);
        bool DepositReverse(Transaction request);
        bool Execute(Transaction request);
    }
}
