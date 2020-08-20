using CONTINER.API.MANAGER.Security.Model;
using CONTINER.API.MANAGER.Security.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CONTINER.API.MANAGER.Security.Service
{
    public class ServiceAccess : IServiceAccess
    {
        private readonly IAccessRepository _accessRepository;
        public ServiceAccess(IAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
        }

        public IEnumerable<Access> GetAll()
        {
            return _accessRepository.GetAll();
        }

        public bool Validate(string userName, string password)
        {
            var list = _accessRepository.GetAll();
            var access = list.Where(x => x.Username == userName && x.Password == password).FirstOrDefault();
            if(access != null)
                return true;
            return false;
        }
    }
}
