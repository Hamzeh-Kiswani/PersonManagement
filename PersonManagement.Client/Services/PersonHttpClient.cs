using System.Net.Http.Json;
using PersonManagement.Shared.DTOs;

public class PersonHttpClient
{
    private readonly HttpClient _http;
    public PersonHttpClient(HttpClient http) => _http = http;

    public Task<List<PersonReadDto>> GetPeopleAsync(int? personId, int skip, int take)
        => _http.GetFromJsonAsync<List<PersonReadDto>>(
            $"api/person?personId={personId}&skip={skip}&take={take}"
        )!;

    public Task<int> AddPersonAsync(PersonCreateDto dto)
        => _http.PostAsJsonAsync("api/person", dto)
                .ContinueWith(t => t.Result.Content.ReadFromJsonAsync<int>()!)
                .Unwrap();

    public Task<int> UpdatePersonAsync(PersonUpdateDto dto)
        => _http.PutAsJsonAsync("api/person", dto)
                .ContinueWith(t => t.Result.Content.ReadFromJsonAsync<int>()!)
                .Unwrap();

    public Task<int> DeletePersonAsync(int id)
        => _http.DeleteAsync($"api/person/{id}")
                .ContinueWith(t => t.Result.Content.ReadFromJsonAsync<int>()!)
                .Unwrap();

    public Task<List<NationalityDto>> GetNationalitiesAsync()
        => _http.GetFromJsonAsync<List<NationalityDto>>("api/nationality")!;

    public Task SeedAsync()
        => _http.PostAsync("api/person/seed", null);

    public Task<int> DeleteAllAsync()
        => _http.DeleteAsync("api/person/all")
                .ContinueWith(t => t.Result.Content.ReadFromJsonAsync<int>()!)
                .Unwrap();

}
