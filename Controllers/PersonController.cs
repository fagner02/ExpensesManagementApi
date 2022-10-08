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
        public async Task<IActionResult> GetAllPeople()
        {
            return Ok(await Task.FromResult(_personService.GetAllPeople()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            return Ok(await Task.FromResult(_personService.GetPersonById(id)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePeopleById(PersonDeleteRequest request)
        {
            await Task.Run(() => _personService.DeleteRange(request));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePeopleById([FromBody] PersonPutRequest request)
        {
            await Task.Run(() => _personService.Update(request));
            return Ok();
        }

        [HttpGet("TotalBalance")]
        public async Task<IActionResult> GetTotalBalance()
        {
            return Ok(await Task.Run(() => _personService.GetTotalBalance()));
        }
    }
}
