using Microsoft.EntityFrameworkCore;
using PersonManagement.Api.Data.Context;
using PersonManagement.Api.Data.Entities;

namespace PersonManagement.Api.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _context;
        public PersonRepository(PersonContext context) =>
            _context = context;

        public async Task<int> AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return person.ID;
        }

        public async Task<int> UpdateAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
            return person.ID;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _context.Persons.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Person with ID {id} not found.");
            _context.Persons.Remove(entity);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<Person>> GetAsync(int? personId, int skip, int take)
        {
            var query = _context.Persons
                                .Include(p => p.Nationality)
                                .AsQueryable();

            if (personId.HasValue)
            {
                return await query
                     .Where(p => p.ID == personId.Value)
                     .ToListAsync();
            }

            return await query
                     .Skip(skip)
                     .Take(take)
                     .ToListAsync();
        }

        public async Task SeedAsync(int count = 10000)
        {
            var rand = new Random();
            var nationalityIds = await _context.Nationalities
                                         .Select(n => n.ID)
                                         .ToListAsync();

            var list = Enumerable.Range(1, count)
                .Select(i => new Person
                {
                    FullName = $"Person {i}",
                    Age = rand.Next(18, 100),
                    NationalityID = nationalityIds[rand.Next(nationalityIds.Count)]
                });

            await _context.Persons.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAllAsync()
        {
            var all = await _context.Persons.ToListAsync();
            var count = all.Count;
            _context.Persons.RemoveRange(all);
            await _context.SaveChangesAsync();
            return count;
        }
    }
}
