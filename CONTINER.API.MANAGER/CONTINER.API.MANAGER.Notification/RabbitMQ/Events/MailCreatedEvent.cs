
using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Events;

namespace CONTINER.API.MANAGER.Notification.RabbitMQ.Events
{
    public class MailCreatedEvent : Event
    {
        public MailCreatedEvent(string sendDate, int accountId)
        {
            SendDate = sendDate;
            AccountId = accountId;
        }

        public string SendDate { get; set; }
        public int AccountId { get; set; }

    }
}
