using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MutantDetector.Infrastructure.Abstractions;

namespace MutantDetector.Infrastructure
{
    public class MutantDetectorDbContext : IMutantDetectorDbContext
    {
        private readonly IMongoDatabase _database = null;
        
        public MutantDetectorDbContext(IOptions<DbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<HumanDnaData> HumansDna
        {
            get
            {
                return _database.GetCollection<HumanDnaData>("HumanDna");
            }
        }
    }
}
