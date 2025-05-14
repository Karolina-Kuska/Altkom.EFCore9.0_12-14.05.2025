using Models;

namespace Services.Interfaces
{
    public interface ICRUDService<T>
    {
        Task<int> CreateAsync(T entity);
        Task<IEnumerable<T>> ReadAllAsync();
        Task<T?> ReadAsync(int id);
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
    }
}
