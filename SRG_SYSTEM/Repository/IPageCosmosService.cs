using SRG_SYSTEM.DataAccess;

namespace SRG_SYSTEM.Repository
{
    public interface IPageCosmosService
    {
        Task AddPageTracker(PageTracker pageTracker);

        Task<PageTracker> GetPageTracker();
        Task<PageTracker> UpdatePageTracker(PageTracker pageTracker);
    }
}
