using Contracts;
using Entities;

namespace Repository;

public class ServiceRepository: RepositoryBase<Service>, IServiceRepository
{
    public ServiceRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
    public IEnumerable<Service> GetAllServices(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();
    public Service GetService(Guid serviceId, bool trackChanges) =>
        FindByCondition(c => c.ServiceId.Equals(serviceId), trackChanges)
            .SingleOrDefault();
}