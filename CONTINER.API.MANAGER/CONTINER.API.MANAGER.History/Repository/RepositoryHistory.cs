using CONTINER.API.MANAGER.History.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CONTINER.API.MANAGER.History.Repository
{
    public class RepositoryHistory : IRepositoryHistory
    {
        private readonly IMongoDatabase _database = null;
        private readonly IConfiguration _configuration;
        public RepositoryHistory(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(configuration["mongo:cn"]);
            if(client != null)
                _database = client.GetDatabase(configuration["mongo:database"]);
        }
        public IMongoCollection<HistoryTransaction> HistoryCredit
        {
            get
            {
                return _database.GetCollection<HistoryTransaction>("HistoryTransaction");
            }
        }
    }
}
