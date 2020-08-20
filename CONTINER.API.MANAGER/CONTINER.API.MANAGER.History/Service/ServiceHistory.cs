using CONTINER.API.MANAGER.History.DTO;
using CONTINER.API.MANAGER.History.Model;
using CONTINER.API.MANAGER.History.Repository;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.History.Service
{
    public class ServiceHistory : IServiceHistory
    {
        private readonly IRepositoryHistory _historyRepository;
        public ServiceHistory(IRepositoryHistory historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<bool> Add(HistoryTransaction historyTransaction)
        {
            await _historyRepository.HistoryCredit.InsertOneAsync(historyTransaction);
            return true;
        }

        public async Task<IEnumerable<HistoryResponse>> GetAll()
        {
            var data = await _historyRepository.HistoryCredit.Find(_ => true).ToListAsync();
            var response = new List<HistoryResponse>();
            foreach(var item in data)
            {
                response.Add(new HistoryResponse()
                {
                    AccountId = item.AccountId,
                    Amount = item.Amount,
                    CreationDate = item.CreationDate,
                    IdTransaction = item.IdTransaction,
                    Type = item.Type
                });
            }
            return response;
        }
    }
}
