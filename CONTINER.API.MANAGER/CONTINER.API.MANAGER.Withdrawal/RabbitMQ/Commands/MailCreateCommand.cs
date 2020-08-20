namespace CONTINER.API.MANAGER.Withdrawal.RabbitMQ.Commands
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
