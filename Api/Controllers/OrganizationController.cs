using Api.Dtos.OrganizationDtos;
using Api.Services.Interfaces;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
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
            var organization = _mapper.Map<Organization>(request);
            await _organizationService.CreateOrganization(organization);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<OrganizationToFrontDto> GetOrganization(Guid id)
        {
            var organization = await _organizationService.GetOrganization(id);
            return _mapper.Map<OrganizationToFrontDto>(organization);
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
            var organization = await _organizationService.GetOrganization(request.Id);
            organization = _mapper.Map(request, organization);
            await _organizationService.UpdateOrganization(organization);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(Guid id)
        {
            await _organizationService.DeleteOrganization(id);
            return Ok();
        }
    }
}
