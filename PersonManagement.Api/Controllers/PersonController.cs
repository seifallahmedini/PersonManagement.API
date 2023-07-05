using Microsoft.AspNetCore.Mvc;
using PersonManagement.Application;
using PersonManagement.Application.Exceptions;

namespace PersonManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(PersonRequestDTO personDto)
        {
            try
            {
                var person = await _personService.AddAsync(personDto);
                return Ok(person);
            }
            catch (InvalidAgeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
