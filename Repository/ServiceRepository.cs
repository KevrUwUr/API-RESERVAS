using Contracts;
using Entities;

namespace Repository;

public class ServiceRepository: RepositoryBase<Service>, IServiceRepository
{
    public ServiceRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
}