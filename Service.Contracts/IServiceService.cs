using Shared.DataTransferObjects.Service;

namespace Service.Contracts;

public interface IServiceService
{
    IEnumerable<ServiceDto> GetAllServices(bool trackChanges);

    ServiceDto GetService(Guid serviceId, bool trackChanges);
}