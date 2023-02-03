using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using SRG_SYSTEM.DataAccess;

namespace SRG_SYSTEM.Repository
{
    public class PageCosmosService:IPageCosmosService
    {
        private readonly Container _container;
        public PageCosmosService(CosmosClient cosmosClient,
        string databaseName,
        string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task AddAsync(PageTracker PageTracker)
        {
             await _container.CreateItemAsync<PageTracker>(PageTracker, new PartitionKey(PageTracker.Id));
        }

        public async Task<PageTracker> GetPageTracker()
        {
            //var query = _container.GetItemQueryIterator<Car>(new QueryDefinition(sqlCosmosQuery));
            PageTracker query = null;
            try
            {
                query = await _container.ReadItemAsync<PageTracker>(id: "1", partitionKey: new PartitionKey("1"));
            }
            catch
            {

            }

            return query;
           
        }

        public async Task<PageTracker> Update(PageTracker pageTracker)
        {
            var item = await _container.UpsertItemAsync<PageTracker>(pageTracker, new PartitionKey("1"));
            return item;
        }
    }
}
