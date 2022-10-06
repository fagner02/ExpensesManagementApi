using ExpensesManagementApi.DataTransferObjects;
using ExpensesManagementApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonPostRequest person)
        {
            await Task.Run(() => _personService.CreatePerson(person));
            return Created("CreatePerson", person);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            return Ok(await Task.FromResult(_personService.GetAllPersons()));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePersonsById(PersonDeleteRequest request)
        {
            await Task.Run(() => _personService.DeleteRange(request));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonsById([FromBody]PersonPutRequest request)
        {
            await Task.Run(() => _personService.UpdateRange(request));
            return Ok();
        }
    }
}
