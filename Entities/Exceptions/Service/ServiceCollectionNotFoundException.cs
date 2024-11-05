namespace Entities.Exceptions.Service;

public class ServiceCollectionNotFoundException : Exception
{
    public ServiceCollectionNotFoundException(string message) : base(message) { }
}
