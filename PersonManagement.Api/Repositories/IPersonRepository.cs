using PersonManagement.Api.Data.Entities;

namespace PersonManagement.Api.Repositories
{
    public interface IPersonRepository
    {
        Task<int> AddAsync(Person person);
        Task<int> UpdateAsync(Person person);
        Task<int> DeleteAsync(int id);
        Task<List<Person>> GetAsync(int? personId, int skip, int take);
        Task SeedAsync(int count = 10000);
        Task<int> DeleteAllAsync();
    }
}
