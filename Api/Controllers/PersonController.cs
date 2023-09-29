using Api.Dtos.PersonDtos;
using Api.Services.Interfaces;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
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
            var person = _mapper.Map<Person>(request);
            await _personService.CreatePerson(person);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<PersonToFrontDto> GetPerson(Guid id)
        {
            var person = await _personService.GetPerson(id);
            return _mapper.Map<PersonToFrontDto>(person);
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
            var person = await _personService.GetPerson(request.Id);
            person = _mapper.Map(request, person);
            await _personService.UpdatePerson(person);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            await _personService.DeletePerson(id);
            return Ok();
        }
    }
}
