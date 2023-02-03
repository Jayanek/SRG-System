namespace SRG_SYSTEM.DataAccess
{
    public interface ICosmosDataAccess<T>
    {
        Task AddAsync(T item);
        Task<T> GetAsync(T query);
        Task<T> UpdateAsync(T item);
    }
}