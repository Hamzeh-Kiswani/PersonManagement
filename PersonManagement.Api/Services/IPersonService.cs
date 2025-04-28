using PersonManagement.Shared.DTOs;

namespace PersonManagement.Api.Services
{
    public interface IPersonService
    {
        Task<int> AddPersonAsync(PersonCreateDto dto);
        Task<int> UpdatePersonAsync(PersonUpdateDto dto);
        Task<int> DeletePersonAsync(int id);
        Task<List<PersonReadDto>> GetPeopleAsync(int? personId, int skip, int take);
        Task SeedPeopleAsync(int count = 10000);

        Task<int> DeleteAllPeopleAsync();
    }
}
