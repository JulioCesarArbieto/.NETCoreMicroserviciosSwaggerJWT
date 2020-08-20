using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Commands;

namespace CONTINER.API.MANAGER.Deposit.RabbitMQ.Commands
{
    public class MailCommand : Command
    {
        public string SendDate { get; protected set; }
        public int AccountId { get; protected set; }
    }
}
