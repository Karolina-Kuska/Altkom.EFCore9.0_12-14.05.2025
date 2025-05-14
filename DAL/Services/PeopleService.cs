using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace DAL.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly DbContext _context;
        public PeopleService(DbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Person entity)
        {
            var dbEntity = _context.Set<Person>().Add(entity);
            await _context.SaveChangesAsync();
            return dbEntity.Entity.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _context.Set<Person>().Remove(new Person { Id = id });
            return (await _context.SaveChangesAsync()) == 1;
        }

        public async Task<IEnumerable<Person>> GetBySearchString(string search)
        {
            return await _context.Set<Person>()
                .AsNoTracking()
                .Where(x => x.FullName.Contains(search))
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Person>> GetPeopleWithAddressAsync()
        {
            return await _context.Set<Person>()
                .Include(x => x.Address)
                .Where(x => x.Address != null)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Person>> ReadAllAsync()
        {
            return await _context.Set<Person>().AsNoTracking().ToArrayAsync();
        }

        public Task<Person?> ReadAsync(int id)
        {
            //_context.Set<Person>().FindAsync(id);   
            return _context.Set<Person>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(int id, Person entity)
        {
            entity.Id = id;
            if (entity.Address?.AddressId > 0)
                _context.Attach(entity.Address);
            _context.Set<Person>().Update(entity);
            return (await _context.SaveChangesAsync()) == 1;
        }
    }
}
