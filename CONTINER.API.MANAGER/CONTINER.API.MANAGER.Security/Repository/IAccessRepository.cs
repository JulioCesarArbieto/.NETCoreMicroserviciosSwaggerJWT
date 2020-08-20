using CONTINER.API.MANAGER.Security.Model;
using System.Collections.Generic;

namespace CONTINER.API.MANAGER.Security.Repository
{
    public interface IAccessRepository
    {
        IEnumerable<Access> GetAll();
    }
}
