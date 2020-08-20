using CONTINER.API.MANAGER.Security.Model;
using System.Collections.Generic;

namespace CONTINER.API.MANAGER.Security.Service
{
    public interface IServiceAccess
    {
        bool Validate(string userName, string password);
        IEnumerable<Access> GetAll();
    }
}
