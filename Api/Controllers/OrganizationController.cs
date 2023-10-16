using Api.Dtos.OrganizationDtos;
using Api.Services.Interfaces;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/organization")]
    [ApiController]
    public class OrganizationController : ApiController
    {
        private readonly IOrganizationService _organizationService;
        private readonly Mapper _mapper;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService ?? throw new ArgumentNullException(nameof(organizationService));
            _mapper = MapperConfig.GetInstance();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganization(CreateOrganizationRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(GetErrorListFromModelState(ModelState));
            }

            var organization = _mapper.Map<Organization>(request);

            if (organization == null)
            {
                return BadRequest("Invalid data provided for creating a new organization.");
            }

            await _organizationService.CreateOrganization(organization);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganization(Guid id)
        {
            var organization = await _organizationService.GetOrganization(id);
            if (organization == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrganizationToFrontDto>(organization));
        }

        [HttpGet("all")]
        public async Task<OrganizationToFrontDto[]> GetAll()
        {
            var organizations = await _organizationService.GetAllOrganizations();
            return _mapper.Map<List<OrganizationToFrontDto>>(organizations).ToArray();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateOrganization(UpdateOrganizationRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(GetErrorListFromModelState(ModelState));
            }

            var organization = await _organizationService.GetOrganization(request.Id);

            if (organization == null)
            {
                return NotFound();
            }

            organization = _mapper.Map(request, organization);

            if (organization == null)
            {
                return BadRequest("Invalid data provided for updating organization.");
            }

            await _organizationService.UpdateOrganization(organization);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(Guid id)
        {
            var organization = await _organizationService.GetOrganization(id);

            if (organization == null)
            {
                return NotFound();
            }

            await _organizationService.DeleteOrganization(organization);
            return Ok();
        }
    }
}
