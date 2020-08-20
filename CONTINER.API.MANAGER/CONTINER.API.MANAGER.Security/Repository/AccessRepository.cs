using CONTINER.API.MANAGER.Security.Model;
using CONTINER.API.MANAGER.Security.Repository.Data;
using System.Collections.Generic;
using System.Linq;

namespace CONTINER.API.MANAGER.Security.Repository
{
    public class AccessRepository : IAccessRepository
    {
        private readonly IContextDatabase _context;
        public AccessRepository(IContextDatabase context)
        {
            _context = context;
        }

        public IEnumerable<Access> GetAll()
        {
            return _context.Access.ToList();
        }
    }
}
