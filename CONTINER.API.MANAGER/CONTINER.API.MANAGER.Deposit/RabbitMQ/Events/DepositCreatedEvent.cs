using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Events;

namespace CONTINER.API.MANAGER.Deposit.RabbitMQ.Events
{
    public class DepositCreatedEvent : Event
    {
        public DepositCreatedEvent(int idTransaction, decimal amount, string type, string creationDate, int accountId)
        {
            IdTransaction = idTransaction;
            Amount = amount;
            Type = type;
            CreationDate = creationDate;
            AccountId = accountId;
        }

        public int IdTransaction { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string CreationDate { get; set; }
        public int AccountId { get; set; }
    }
}
