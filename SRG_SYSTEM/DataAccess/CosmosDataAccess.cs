using Microsoft.Azure.Cosmos;

namespace SRG_SYSTEM.DataAccess
{
    public class CosmosDataAccess<T> : ICosmosDataAccess<T>
    {
        private readonly Container _container;
        private readonly string defaultPartionKey;

        public CosmosDataAccess(CosmosClient cosmosClient,
        string databaseName,
        string containerName, string defaultPartionKey)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
            this.defaultPartionKey = defaultPartionKey;
        }

        public async Task AddAsync(T item)
        {
            await _container.CreateItemAsync<T>(item, new PartitionKey(defaultPartionKey));
        }

        public async Task<T> GetAsync(T query)
        {

            try
            {
                query = await _container.ReadItemAsync<T>(id: "1", partitionKey: new PartitionKey(defaultPartionKey));
            }
            catch
            {
                Console.WriteLine("Empty item");
            }

            return query;

        }

        public async Task<T> UpdateAsync(T item)
        {
            return await _container.UpsertItemAsync<T>(item, new PartitionKey(defaultPartionKey));
        }
    }
}
