using API.Entities;

namespace Api.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<Organization> CreateOrganization(Organization organization);

        Task<Organization> GetOrganization(Guid id);

        Task<IEnumerable<Organization>> GetAllOrganizations();

        Task UpdateOrganization(Organization organization);

        Task DeleteOrganization(Organization organization);
    }
}
