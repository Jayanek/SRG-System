using SRG_SYSTEM.DataAccess;

namespace SRG_SYSTEM.Repository
{
    public interface IPageCosmosService
    {
        Task AddAsync(PageTracker pageTracker);

        Task<PageTracker> GetPageTracker();
        Task<PageTracker> Update(PageTracker pageTracker);
    }
}
