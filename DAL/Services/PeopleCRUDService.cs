using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace DAL.Services
{
    public class PeopleCRUDService : CRUDService<Person>, IPeopleService
    {
        public PeopleCRUDService(DbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Person>> GetBySearchString(string search)
        {
            return await Context.Set<Person>()
                .AsNoTracking()
                .Where(x => x.FullName.Contains(search))
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Person>> GetPeopleWithAddressAsync()
        {
            return await Context.Set<Person>()
                .Include(x => x.Address)
                .Where(x => x.Address != null)
                .ToArrayAsync();
        }

        public override Task<bool> UpdateAsync(int id, Person entity)
        {
            if (entity.Address?.AddressId > 0)
                Context.Attach(entity.Address);

            return base.UpdateAsync(id, entity);
        }
    }
}
