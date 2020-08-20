using CONTINER.API.MANAGER.Notification.Model;
using CONTINER.API.MANAGER.Notification.Repository;
using System.Collections.Generic;

namespace CONTINER.API.MANAGER.Notification.Service
{
    public class ServiceMail : IServiceMail
    {
        private readonly IRepositoryMail _mailRepository;
        public ServiceMail(IRepositoryMail mailRepository)
        {
            _mailRepository = mailRepository;
        }

        public bool Add(SendMail sendMail)
        {
            return _mailRepository.Add(sendMail);
        }

        public IEnumerable<SendMail> GetAll()
        {
            return _mailRepository.GetAll();
        }
    }
}
