using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagement.Api.Data.Context;

namespace PersonManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalityController : ControllerBase
    {
        private readonly PersonContext _ctx;
        public NationalityController(PersonContext ctx) => _ctx = ctx;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _ctx.Nationalities
                            .Select(n => new { n.ID, n.Name })
                            .ToListAsync());
    }

}
