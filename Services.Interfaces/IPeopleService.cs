using Models;

namespace Services.Interfaces
{
    public interface IPeopleService
    {
        #region CRUD
        Task<int> CreateAsync(Person entity);
        Task<IEnumerable<Person>> ReadAllAsync();
        Task<Person?> ReadAsync(int id);
        Task<bool> UpdateAsync(int id, Person entity);
        Task<bool> DeleteAsync(int id);
        #endregion

        Task<IEnumerable<Person>> GetPeopleWithAddressAsync();
        Task<IEnumerable<Person>> GetBySearchString(string search);
    }
}
