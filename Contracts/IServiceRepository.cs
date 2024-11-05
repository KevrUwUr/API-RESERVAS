using Entities;

namespace Contracts;

public interface IServiceRepository
{
    IEnumerable<Service> GetAllServices(bool trackChanges);

    Service GetService(Guid serviceId, bool trackChanges);

}