namespace CONTINER.API.MANAGER.Deposit.RabbitMQ.Commands
{
    public class DepositCreateCommand : DepositCommand
    {
        public DepositCreateCommand(int idTransaction, decimal amount, string type, string creationDate, int accountId)
        {
            IdTransaction = idTransaction;
            Amount = amount;
            Type = type;
            CreationDate = creationDate;
            AccountId = accountId;
        }
    }
}
