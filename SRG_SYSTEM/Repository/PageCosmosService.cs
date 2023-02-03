using SRG_SYSTEM.DataAccess;

namespace SRG_SYSTEM.Repository
{
    public class PageCosmosService : IPageCosmosService
    {
        private readonly ICosmosDataAccess<PageTracker> _cosmosDataAccess;

        public PageCosmosService(ICosmosDataAccess<PageTracker> cosmosDataAccess)
        {
            _cosmosDataAccess = cosmosDataAccess;
        }

        public async Task AddPageTracker(PageTracker PageTracker)
        {
            await _cosmosDataAccess.AddAsync(PageTracker);
        }

        public async Task<PageTracker> GetPageTracker()
        {
            PageTracker query = null;
            return await _cosmosDataAccess.GetAsync(query);

        }

        public async Task<PageTracker> UpdatePageTracker(PageTracker pageTracker)
        {
            return await _cosmosDataAccess.UpdateAsync(pageTracker);

        }
    }
}
