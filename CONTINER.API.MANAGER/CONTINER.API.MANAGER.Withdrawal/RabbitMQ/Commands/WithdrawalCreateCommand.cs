namespace CONTINER.API.MANAGER.Withdrawal.RabbitMQ.Commands
{
    public class WithdrawalCreateCommand : WithdrawalCommand
    {
        public WithdrawalCreateCommand(int idTransaction, decimal amount, string type, string creationDate, int accountId)
        {
            IdTransaction = idTransaction;
            Amount = amount;
            Type = type;
            CreationDate = creationDate;
            AccountId = accountId;
        }
    }
}
