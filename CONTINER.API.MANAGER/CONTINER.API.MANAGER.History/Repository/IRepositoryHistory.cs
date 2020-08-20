using CONTINER.API.MANAGER.History.Model;
using MongoDB.Driver;

namespace CONTINER.API.MANAGER.History.Repository
{
    public interface IRepositoryHistory
    {
        IMongoCollection<HistoryTransaction> HistoryCredit { get; }
    }
}
