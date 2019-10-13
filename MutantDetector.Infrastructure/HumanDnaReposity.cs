using MongoDB.Bson;
using MongoDB.Driver;
using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;
using MutantDetector.Infrastructure.Abstractions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MutantDetector.Infrastructure
{
    public class HumanDnaReposity : IHumanDnaReposity
    {
        private readonly IMutantDetectorDbContext _dbContext;

        public HumanDnaReposity(IMutantDetectorDbContext mutantDetectorDbContext)
        {
            _dbContext = mutantDetectorDbContext;

        }
        public async Task Save(HumanDna humanDna, bool isMutant)
        {
            var dna = humanDna.ToString();
            var newId = GetHash(dna);
            var humanDnaData = new HumanDnaData(newId, dna, isMutant);
            
            await _dbContext.HumansDna.ReplaceOneAsync(
                        filter: i => i.Id == newId,
                        options: new UpdateOptions { IsUpsert = true },
                        replacement: humanDnaData);               
        }

        public async Task<HumansDnaSummary> GetSumary()
        {
            var humansCountTask = _dbContext.HumansDna.CountDocumentsAsync(new BsonDocument());
            var mutantCountTask = _dbContext.HumansDna.CountDocumentsAsync(h => h.IsMutant);

            await Task.WhenAll(humansCountTask, mutantCountTask);

            return new HumansDnaSummary(mutantCountTask.Result, humansCountTask.Result);
        }

        private static string GetHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                
                var sBuilder = new StringBuilder();
                
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }           
        }
    }
}
