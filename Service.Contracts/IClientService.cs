using Entities;
using Shared.DataTransferObjects.Client;

namespace Service.Contracts;

public interface IClientService
{
    IEnumerable<ClientDto> GetAllClients(bool trackChanges);
    ClientDto GetClient(Guid clientId, bool trackChanges);

}