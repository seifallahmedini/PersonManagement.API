using Microsoft.AspNetCore.Mvc;
using PersonManagement.Application;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(PersonDTO personDto)
        {
            var person = await _personService.AddAsync(personDto);
            return Ok(person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, PersonDTO personDto)
        {
            try
            {
                var updatedPerson = await _personService.UpdateAsync(id, personDto);
                return Ok(updatedPerson);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var person = await _personService.DeleteAsync(id);
            return Ok(person);
        }
    }
}
