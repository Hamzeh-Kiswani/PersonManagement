using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Api.Services;
using PersonManagement.Shared.DTOs;

namespace PersonManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        public PersonController(IPersonService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonCreateDto dto)
            => Ok(await _service.AddPersonAsync(dto));

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(PersonUpdateDto dto)
            => Ok(await _service.UpdatePersonAsync(dto));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePerson(int id)
            => Ok(await _service.DeletePersonAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetPerson([FromQuery] int? personId, [FromQuery] int skip = 0, [FromQuery] int take = 10)
            => Ok(await _service.GetPeopleAsync(personId, skip, take));

        [HttpPost("seed")]
        public async Task<IActionResult> SeedPerson()
        {
            await _service.SeedPeopleAsync();
            return Ok(new { seeded = true });
        }

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAllPersons()
        {
            var count = await _service.DeleteAllPeopleAsync();
            return Ok(count);
        }
    }

}
