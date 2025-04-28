using PersonManagement.Api.Repositories;
using PersonManagement.Api.Data.Entities;
using PersonManagement.Shared.DTOs;

namespace PersonManagement.Api.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repo;
        public PersonService(IPersonRepository repo) =>
            _repo = repo;

        public async Task<int> AddPersonAsync(PersonCreateDto dto)
        {
            var entity = new Person
            {
                FullName = dto.FullName,
                Age = dto.Age,
                NationalityID = dto.NationalityID
            };
            return await _repo.AddAsync(entity); 
        }

        public async Task<int> UpdatePersonAsync(PersonUpdateDto dto)
        {
            var entity = new Person
            {
                ID = dto.ID,
                FullName = dto.FullName,
                Age = dto.Age,
                NationalityID = dto.NationalityID
            };
            return await _repo.UpdateAsync(entity);
        }

        public async Task<int> DeletePersonAsync(int id) =>
            await _repo.DeleteAsync(id);

        public async Task<List<PersonReadDto>> GetPeopleAsync(int? personId, int skip, int take)
        {
            var entities = await _repo.GetAsync(personId, skip, take);
            return entities.Select(p => new PersonReadDto
            {
                ID = p.ID,
                FullName = p.FullName,
                Age = p.Age,
                NationalityID = p.NationalityID,
                NationalityName = p.Nationality?.Name
            })
            .ToList();
        }

        public async Task SeedPeopleAsync(int count = 10000) =>
            await _repo.SeedAsync(count);

        public async Task<int> DeleteAllPeopleAsync()
        => await _repo.DeleteAllAsync();
    }
}
