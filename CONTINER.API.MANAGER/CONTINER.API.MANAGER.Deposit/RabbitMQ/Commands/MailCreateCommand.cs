namespace CONTINER.API.MANAGER.Deposit.RabbitMQ.Commands
{
    public class MailCreateCommand : MailCommand
    {
        public MailCreateCommand(string sendDate, int accountId)
        {
            SendDate = sendDate;
            AccountId = accountId;
        }
    }
}
