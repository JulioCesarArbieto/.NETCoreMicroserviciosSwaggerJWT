using CONTINER.API.MANAGER.History.DTO;
using CONTINER.API.MANAGER.History.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.History.Service
{
    public interface IServiceHistory
    {
        Task<IEnumerable<HistoryResponse>> GetAll();

        Task<bool> Add(HistoryTransaction historyTransaction);
    }
}
