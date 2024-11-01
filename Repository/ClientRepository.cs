using Entities;
using Contracts;

namespace Repository;

public class ClientRepository: RepositoryBase<Client>, IClientRepository
{
    public ClientRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
    
    public IEnumerable<Client> GetAllClients(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();
    public Client GetClient(Guid clientId, bool trackChanges) =>
        FindByCondition(c => c.ClientId.Equals(clientId), trackChanges)
            .SingleOrDefault();
}