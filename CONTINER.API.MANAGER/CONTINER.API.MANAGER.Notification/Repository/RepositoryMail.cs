using CONTINER.API.MANAGER.Notification.Model;
using CONTINER.API.MANAGER.Notification.Repository.Data;
using System.Collections.Generic;
using System.Linq;

namespace CONTINER.API.MANAGER.Notification.Repository
{
    public class RepositoryMail : IRepositoryMail
    {
        private readonly IContextDatabase _context;
        public RepositoryMail(IContextDatabase context)
        {
            _context = context;
        }

        public bool Add(SendMail sendMail)
        {
            _context.SendMail.Add(sendMail);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<SendMail> GetAll()
        {
            return _context.SendMail.ToList();
        }
    }
}
