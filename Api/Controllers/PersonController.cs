using Api.Dtos.PersonDtos;
using Api.Services.Interfaces;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ApiController
    {
        private readonly IPersonService _personService;
        private readonly Mapper _mapper;
        public PersonController(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _mapper = MapperConfig.GetInstance();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(CreatePersonRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(GetErrorListFromModelState(ModelState));
            }

            var person = _mapper.Map<Person>(request);

            if (person == null)
            {
                return BadRequest("Invalid data provided for creating a new person.");
            }

            await _personService.CreatePerson(person);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            var person = await _personService.GetPerson(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PersonToFrontDto>(person));
        }

        [HttpGet("all")]
        public async Task<PersonToFrontDto[]> GetAll()
        {
            var persons = await _personService.GetAllPersons();
            return _mapper.Map<List<PersonToFrontDto>>(persons).ToArray();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePerson(UpdatePersonRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(GetErrorListFromModelState(ModelState));
            }

            var person = await _personService.GetPerson(request.Id);

            if (person == null)
            {
                return NotFound();
            }

            person = _mapper.Map(request, person);

            if (person == null)
            {
                return BadRequest("Invalid data provided for updating person.");
            }

            await _personService.UpdatePerson(person);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var person = await _personService.GetPerson(id);

            if (person == null)
            {
                return NotFound();
            }

            await _personService.DeletePerson(person);
            return Ok();
        }

    }
}
