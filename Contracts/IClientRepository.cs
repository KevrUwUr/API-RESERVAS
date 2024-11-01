using Entities;

namespace Contracts;

public interface IClientRepository
{
        IEnumerable<Client> GetAllClients(bool trackChanges);
        Client GetClient(Guid clientId, bool trackChanges);

}