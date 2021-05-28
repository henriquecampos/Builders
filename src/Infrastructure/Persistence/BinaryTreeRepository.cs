using Builders.Application.Common.Interfaces;
using Builders.Domain.Entities;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Builders.Infrastructure.Persistence
{
    public class BinaryTreeRepository : IBinaryTreeRepository
    {
        private const string CollectionName = "tree";
        private readonly IMongoDatabase _database;

        public BinaryTreeRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Node> GetRoot()
        {
            return await _database.GetCollection<Node>(CollectionName)
                    .AsQueryable()
                     .FirstOrDefaultAsync();
        }

        public async Task Insert(Node root)
        {
            await _database.GetCollection<Node>(CollectionName)
                .InsertOneAsync(root);
        }

        public async Task Replace(Node root)
        {
            await _database.GetCollection<Node>(CollectionName)
                .ReplaceOneAsync(x => true, root);
        }
    }
}
